Public Class Main

    ' A subroutine that will execute a .EXE and wait til its done.
    Sub DoCMD(ByVal file As String, ByVal arg As String)
        Dim procNlite As New Process
        winstyle = 1
        procNlite.StartInfo.FileName = file
        procNlite.StartInfo.Arguments = " " & arg
        procNlite.StartInfo.WindowStyle = winstyle
        Application.DoEvents()
        procNlite.Start()
        Do Until procNlite.HasExited
            Application.DoEvents()
            For i = 0 To 5000000
                Application.DoEvents()
            Next
        Loop
        procNlite.WaitForExit()
    End Sub



    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Size = New Size(385, 165)

        Panel1.Location = New Point(3, 3)
        Panel2.Location = New Point(3, 3)
        Panel3.Location = New Point(3, 3)

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Button3.Enabled = False
        Button3.Text = "Sending payload"
        DoCMD("irecovery.exe", "-k iboot.payload")

        Button3.Text = "Sending iBEC"
        DoCMD("irecovery.exe", "-f ibec.40")

        Button3.Text = "Setting up iBEC..."
        DoCMD("irecovery.exe", "-c go")

        Button3.Text = "Waiting for iBEC to load up.."
        System.Threading.Thread.Sleep(2000)

        Button3.Text = "Sending Device Tree"
        DoCMD("irecovery.exe", "-f devtree.40")

        Button3.Text = "Setting up Device Tree..."
        DoCMD("irecovery.exe", "-c devicetree")

        Button3.Text = "Sending Logo"
        DoCMD("irecovery.exe", "-f sn0w.img3")

        Button3.Text = "Setting up Logo..."
        DoCMD("irecovery.exe", "-c setpicture 1")
        DoCMD("irecovery.exe", "-c bgcolor ""1 1 1"" ")

        Button3.Text = "Sending Kernel cache"
        DoCMD("irecovery.exe", "-f kernel.40")

        Button3.Text = "Booting.."
        DoCMD("irecovery.exe", "-c bootx")

        For i = 30 To 0 Step -1
            Button3.Text = "Booting.. (" & i & ")"
        Next

        Button3.Text = "Your iDevice is supposed to be Booted now!"

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        Button4.Enabled = False
        Button4.Text = "Sending payload"
        DoCMD("irecovery.exe", "-k iboot.payload")

        Button4.Text = "Sending Logo"
        DoCMD("irecovery.exe", "-f wait.img3")

        Button4.Text = "Setting up Logo..."
        DoCMD("irecovery.exe", "-c setpicture 1")
        DoCMD("irecovery.exe", "-c bgcolor ""1 1 1"" ")

        Button4.Text = "iDevice is ready for restoring :)"

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Panel1.Visible = False
        Panel2.Visible = True

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Panel1.Visible = False
        Panel3.Visible = True

    End Sub

End Class


