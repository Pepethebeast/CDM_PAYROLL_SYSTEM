Imports Emgu.CV
Imports Emgu.CV.CvEnum
Imports Emgu.CV.Structure
Imports Emgu.CV.Face
Imports DirectShowLib
Imports System.Threading.Tasks
Imports System.Threading
Imports System.IO

Public Class FaceRecognitionForm
    'Private capturing As VideoCapture
    'Private faceCascade As CascadeClassifier
    'Private cameraTask As Task
    'Private cts As New CancellationTokenSource()
    'Private isFormClosing As Boolean = False

    'Private Async Sub FaceRecognitionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    faceCascade = New CascadeClassifier("haarcascade_frontalface_default.xml")
    '    PictureBox4.SizeMode = PictureBoxSizeMode.StretchImage
    '    Label1.Visible = False
    '    Await PopulateCameraListAsync()
    'End Sub

    'Private Async Function PopulateCameraListAsync() As Task
    '    Await Task.Run(Sub()
    '                       Dim cameras As List(Of DsDevice) = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice).ToList()
    '                       If Not isFormClosing Then
    '                           Me.Invoke(Sub()
    '                                         For Each cam In cameras
    '                                             ComboBox1.Items.Add(cam.Name)
    '                                         Next
    '                                         If ComboBox1.Items.Count > 0 Then
    '                                             ComboBox1.SelectedIndex = 0
    '                                         Else
    '                                             MessageBox.Show("No camera found.")
    '                                         End If
    '                                     End Sub)
    '                       End If
    '                   End Sub)
    'End Function

    'Private Async Sub btnStart_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    If ComboBox1.SelectedIndex = -1 Then
    '        MessageBox.Show("Please select a camera.")
    '        Return
    '    End If

    '    Await StopCameraAsync()

    '    If Not isFormClosing Then
    '        Label1.Visible = True
    '        Label1.Text = "Opening..."

    '        cts = New CancellationTokenSource()
    '        cameraTask = StartCameraAsync(ComboBox1.SelectedIndex, cts.Token)
    '    End If
    'End Sub

    'Private Async Function StartCameraAsync(cameraIndex As Integer, ct As CancellationToken) As Task
    '    Try
    '        Await Task.Run(Async Function()
    '                           capturing = New VideoCapture(cameraIndex)
    '                           If Not capturing.IsOpened Then
    '                               Throw New Exception("Unable to open camera with index " & cameraIndex)
    '                           End If

    '                           If Not isFormClosing Then
    '                               Me.Invoke(Sub() Label1.Text = "Detecting faces...")
    '                           End If

    '                           While Not ct.IsCancellationRequested AndAlso Not isFormClosing
    '                               Await ProcessFrameAsync(ct)
    '                           End While
    '                       End Function, ct)
    '    Catch ex As OperationCanceledException
    '    Catch ex As Exception
    '        If Not isFormClosing Then
    '            Me.Invoke(Sub()
    '                          MessageBox.Show("Error: " & ex.Message)
    '                          Label1.Visible = False
    '                      End Sub)
    '        End If
    '    Finally
    '        If capturing IsNot Nothing Then
    '            capturing.Dispose()
    '            capturing = Nothing
    '        End If
    '    End Try
    'End Function

    'Private Async Function ProcessFrameAsync(ct As CancellationToken) As Task
    '    If capturing Is Nothing OrElse isFormClosing Then Return

    '    Dim frame As Mat = capturing.QueryFrame()
    '    If frame Is Nothing Then Return

    '    Dim grayFrame As New Mat()
    '    CvInvoke.CvtColor(frame, grayFrame, ColorConversion.Bgr2Gray)

    '    Dim faces As Rectangle() = faceCascade.DetectMultiScale(grayFrame, 1.1, 10)

    '    For Each face As Rectangle In faces
    '        CvInvoke.Rectangle(frame, face, New MCvScalar(255, 0, 0), 2)
    '    Next

    '    Dim image As Image(Of Bgr, Byte) = frame.ToImage(Of Bgr, Byte)()

    '    Dim resizedImage As Image(Of Bgr, Byte) = image.Resize(PictureBox4.Width, PictureBox4.Height, Inter.Linear)

    '    If Not isFormClosing Then
    '        Me.Invoke(Sub()
    '                      If Not isFormClosing Then
    '                          PictureBox4.Image = resizedImage.ToBitmap()
    '                          UpdateFaceDetectionLabel(faces.Length > 0)
    '                      End If
    '                  End Sub)
    '    End If

    '    Await Task.Delay(15, ct)
    'End Function

    'Private Sub UpdateFaceDetectionLabel(isFaceDetected As Boolean)
    '    If isFormClosing Then Return
    '    If Me.InvokeRequired Then
    '        Me.Invoke(Sub() UpdateFaceDetectionLabel(isFaceDetected))
    '    Else
    '        Label1.Text = If(isFaceDetected, "FACE DETECTED", "FACE NOT DETECTED")
    '        Label1.Visible = True
    '    End If
    'End Sub

    'Private Async Sub FaceRecognitionForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
    '    isFormClosing = True
    '    Await StopCameraAsync()
    'End Sub

    'Private Async Function StopCameraAsync() As Task
    '    If cameraTask IsNot Nothing Then
    '        cts.Cancel()
    '        Await cameraTask
    '        cts.Dispose()
    '    End If
    'End Function
    Private capturing As VideoCapture
    Private faceCascade As CascadeClassifier
    Private cameraTask As Task
    Private cts As New CancellationTokenSource()
    Private isFormClosing As Boolean = False
    Private faceRecognizer As LBPHFaceRecognizer
    Private registeredFaces As New Dictionary(Of String, Integer)()

    Private Async Sub FaceRecognitionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        faceCascade = New CascadeClassifier("haarcascade_frontalface_default.xml")
        faceRecognizer = New LBPHFaceRecognizer()
        PictureBox4.SizeMode = PictureBoxSizeMode.StretchImage
        Label1.Visible = False
        Await PopulateCameraListAsync()
    End Sub

    Private Async Function PopulateCameraListAsync() As Task
        Await Task.Run(Sub()
                           Dim cameras As List(Of DsDevice) = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice).ToList()
                           If Not isFormClosing Then
                               Me.Invoke(Sub()
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
                       End Sub)
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

            ' Extract the face from the frame
            Dim faceImage As Mat = New Mat(frame, face)
            Dim grayFace As New Image(Of Gray, Byte)(faceImage.ToBitmap())

            ' Recognize the face
            Dim result As FaceRecognizer.PredictionResult = faceRecognizer.Predict(grayFace)

            If result.Label >= 0 Then
                ' Recognized face
                Dim recognizedUserId As String = registeredFaces.FirstOrDefault(Function(kvp) kvp.Value = result.Label).Key
                Label1.Text = "Recognized: " & recognizedUserId
            Else
                Label1.Text = "Unknown face"
            End If

            ' Optional: Register new face if needed
            ' Call RegisterFace(faceImage, "new_user_id") if you want to add new faces dynamically
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

    Private Async Function RegisterFace(faceImage As Mat, userId As String) As Task
        Using bmp As Bitmap = faceImage.ToBitmap()
            Dim grayImage As New Image(Of Gray, Byte)(bmp)

            ' Register new face and update the recognizer
            If Not registeredFaces.ContainsKey(userId) Then
                registeredFaces.Add(userId, registeredFaces.Count) ' Assign a new label
            End If

            ' Train the recognizer with existing faces
            Dim trainingImages As New List(Of Image(Of Gray, Byte))()
            Dim labels As New List(Of Integer)()

            For Each kvp In registeredFaces
                Dim existingFace As Image(Of Gray, Byte) = Await LoadFaceImageFromFirebase(kvp.Key) ' Implement this method
                trainingImages.Add(existingFace)
                labels.Add(kvp.Value)
            Next

            ' Add the new face to the training set
            trainingImages.Add(grayImage)
            labels.Add(registeredFaces(userId))

            ' Train the recognizer
            faceRecognizer.Train(trainingImages.ToArray(), labels.ToArray())

            ' Optionally upload the new face image to Firebase
            Dim base64Image As String = Convert.ToBase64String(imageBytes) ' Convert to base64 as shown earlier
            Await UploadFaceToFirebase(base64Image, userId) ' Implement this method to upload
        End Using
    End Function

    Private Sub UpdateFaceDetectionLabel(isFaceDetected As Boolean)
        If isFormClosing Then Return
        If Me.InvokeRequired Then
            Me.Invoke(Sub() UpdateFaceDetectionLabel(isFaceDetected))
        Else
            Label1.Text = If(isFaceDetected, "FACE DETECTED", "FACE NOT DETECTED")
            Label1.Visible = True
        End If
    End Sub

    Private Async Sub FaceRecognitionForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        isFormClosing = True
        Await StopCameraAsync()
    End Sub

    Private Async Function StopCameraAsync() As Task
        If cameraTask IsNot Nothing Then
            cts.Cancel()
            Await cameraTask
            cts.Dispose()
        End If
    End Function

End Class
