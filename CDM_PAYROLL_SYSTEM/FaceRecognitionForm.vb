Imports Emgu.CV
Imports Emgu.CV.CvEnum
Imports Emgu.CV.Structure
Imports Emgu.CV.Face
Imports DirectShowLib
Imports System.Threading.Tasks
Imports System.Threading
Imports System.IO
Imports FireSharp
Imports System.Management
Imports FireSharp.Interfaces
Imports FireSharp.Response
Imports System.Drawing.Imaging
Imports Firebase.Database.Client

Public Class FaceRecognitionForm

    Public Property FRF As String
    Public Property UIDFace As String
    Public Property EMAILFOR_Add_Employee As String

    Private capturing As VideoCapture
    Private faceCascade As CascadeClassifier
    Private cameraTask As Task
    Private cts As New CancellationTokenSource()
    Private isFormClosing As Boolean = False
    Private deviceWatcher As ManagementEventWatcher
    Dim firebaseclient123 As IFirebaseClient = FirebaseModule.GetFirebaseClient()
    Private Async Sub FaceRecognitionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button2.Visible = False
        faceCascade = New CascadeClassifier("haarcascade_frontalface_default.xml")
        PictureBox4.SizeMode = PictureBoxSizeMode.StretchImage

        Try
            Dim firebaseclient123 As IFirebaseClient = FirebaseModule.GetFirebaseClient()
        Catch ex As Exception
            MessageBox.Show("ERROR CONNECTING TO FIREBASE, CHECK YOUR CONNECTIONS AND INTERNET!")
            Me.Close()
        End Try

        ' Start watching for camera device changes
        StartDeviceWatcher()

        ' Populate initial camera list
        Await PopulateCameraListAsync()
    End Sub

    Private Sub StartDeviceWatcher()
        Dim query As New WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 2 OR EventType = 3")
        deviceWatcher = New ManagementEventWatcher(query)
        AddHandler deviceWatcher.EventArrived, AddressOf OnDeviceChanged
        deviceWatcher.Start()
    End Sub

    Private Sub OnDeviceChanged(sender As Object, e As EventArrivedEventArgs)
        If isFormClosing Then Return

        ' Refresh the camera list
        Me.Invoke(Async Function()
                      Await PopulateCameraListAsync()
                      Return Task.CompletedTask
                  End Function)
    End Sub

    Private Async Function PopulateCameraListAsync() As Task
        Await Task.Run(Function()
                           Dim cameras As List(Of DsDevice) = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice).ToList()
                           If Not isFormClosing Then
                               Me.Invoke(Sub()
                                             ComboBox1.Items.Clear()
                                             For Each cam In cameras
                                                 ComboBox1.Items.Add(cam.Name)
                                             Next
                                             If ComboBox1.Items.Count > 0 Then
                                                 ComboBox1.SelectedIndex = 0
                                             Else
                                                 MessageBox.Show("No camera found.")
                                             End If
                                         End Sub)
                           End If

                           ' Ensure the function returns a Task.
                           Return Task.CompletedTask
                       End Function)
    End Function

    Private Async Sub btnStart_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.SelectedIndex = -1 Then
            MessageBox.Show("Please select a camera.")
            Return
        End If

        Await StopCameraAsync()

        If Not isFormClosing Then
            Label1.Visible = True
            Label1.Text = "Opening..."

            cts = New CancellationTokenSource()
            cameraTask = StartCameraAsync(ComboBox1.SelectedIndex, cts.Token)
        End If
    End Sub

    Private Async Function StartCameraAsync(cameraIndex As Integer, ct As CancellationToken) As Task
        Try
            Await Task.Run(Async Function()
                               capturing = New VideoCapture(cameraIndex)
                               If Not capturing.IsOpened Then
                                   Throw New Exception("Unable to open camera with index " & cameraIndex)
                               End If

                               If Not isFormClosing Then
                                   Me.Invoke(Sub() Label1.Text = "Detecting faces...")
                               End If

                               While Not ct.IsCancellationRequested AndAlso Not isFormClosing
                                   Await ProcessFrameAsync(ct)
                               End While
                           End Function, ct)
        Catch ex As OperationCanceledException
        Catch ex As Exception
            If Not isFormClosing Then
                Me.Invoke(Sub()
                              MessageBox.Show("Error: " & ex.Message)
                              Label1.Visible = False
                          End Sub)
            End If
        Finally
            If capturing IsNot Nothing Then
                capturing.Dispose()
                capturing = Nothing
            End If
        End Try
    End Function

    Private Async Function ProcessFrameAsync(ct As CancellationToken) As Task
        If capturing Is Nothing OrElse isFormClosing Then Return

        Dim frame As Mat = capturing.QueryFrame()
        If frame Is Nothing Then Return

        Dim grayFrame As New Mat()
        CvInvoke.CvtColor(frame, grayFrame, ColorConversion.Bgr2Gray)

        Dim faces As Rectangle() = faceCascade.DetectMultiScale(grayFrame, 1.1, 10)

        For Each face As Rectangle In faces
            CvInvoke.Rectangle(frame, face, New MCvScalar(255, 0, 0), 2)
        Next

        Dim image As Image(Of Bgr, Byte) = frame.ToImage(Of Bgr, Byte)()

        Dim resizedImage As Image(Of Bgr, Byte) = image.Resize(PictureBox4.Width, PictureBox4.Height, Inter.Linear)

        If Not isFormClosing Then
            Me.Invoke(Sub()
                          If Not isFormClosing Then
                              PictureBox4.Image = resizedImage.ToBitmap()
                              UpdateFaceDetectionLabel(faces.Length > 0)
                          End If
                      End Sub)
        End If

        Await Task.Delay(15, ct)
    End Function

    Private Sub UpdateFaceDetectionLabel(isFaceDetected As Boolean)
        If isFormClosing Then Return
        If Me.InvokeRequired Then
            Me.Invoke(Sub() UpdateFaceDetectionLabel(isFaceDetected))
        Else
            Label1.Text = If(isFaceDetected, "NAME: " + FRF, "FACE NOT DETECTED")
            Label1.Visible = True
            Button2.Visible = isFaceDetected ' Show Register button if a face is detected
        End If
    End Sub

    Private Async Sub FaceRecognitionForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        isFormClosing = True
        If deviceWatcher IsNot Nothing Then
            deviceWatcher.Stop()
            deviceWatcher.Dispose()
        End If
        Await StopCameraAsync()
    End Sub

    Private Async Function StopCameraAsync() As Task
        If cameraTask IsNot Nothing Then
            cts.Cancel()
            Await cameraTask
            cts.Dispose()
        End If
    End Function

    Private Async Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If PictureBox4.Image IsNot Nothing Then
            Try
                ' Convert the face in PictureBox4 to Base64
                Dim faceImage As New Bitmap(PictureBox4.Image)
                Dim memoryStream As New MemoryStream()
                faceImage.Save(memoryStream, ImageFormat.Jpeg)
                Dim imageBytes As Byte() = memoryStream.ToArray()
                Dim base64Image As String = Convert.ToBase64String(imageBytes)
                Dim Timestamper = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")

                ' Define the UID for the face (use UIDFace or another identifier)
                Dim faceData As New PersonalData With {
                     .face_id = base64Image,
                     .time_stamp = Timestamper
                }

                ' Save the face data to Firebase
                Dim response As SetResponse = Await firebaseclient123.SetAsync($"usersTbl/{UIDFace}", faceData)

                If response.StatusCode = System.Net.HttpStatusCode.OK Then
                    MessageBox.Show("Face registered successfully!")

                    Me.Hide()
                Else
                    MessageBox.Show("Failed to register face. Try again.")
                End If
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        Else
            MessageBox.Show("No face detected!")
        End If
    End Sub
End Class