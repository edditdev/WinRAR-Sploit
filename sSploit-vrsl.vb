Imports System.Security.Principal

Public Class Form1
    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Me.Close()
    End Sub
    Private Sub RestartAsAdministrator()
        Dim startInfo As New ProcessStartInfo()
        startInfo.FileName = Application.ExecutablePath
        startInfo.Verb = "runas" 
        Try
            Process.Start(startInfo)
            Application.Exit() 
        Catch ex As Exception
            MsgBox("Failed running program as admin. Please do it manually" & vbNewLine & " > Right-Click on program and 'Run as Administrator'")
        End Try
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            PathTxt.Text = "C:\Program Files\WinRAR\"
            Shad.SetShadowForm(Me)

            If Not IsUserAdministrator() Then
                MessageBox.Show("Program is not running as Admin." & vbNewLine & ">   Right-Click on icon and Run as administrator.", "No Admin permissions", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                RestartAsAdministrator()
            End If

            Main()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            PathTxt.Text = FolderBrowserDialog1.SelectedPath.ToString
        End If
    End Sub
    Private Function IsUserAdministrator() As Boolean
        Dim isAdmin As Boolean = False
        Dim user As WindowsIdentity = WindowsIdentity.GetCurrent()
        Dim principal As New WindowsPrincipal(user)

        If principal.IsInRole(WindowsBuiltInRole.Administrator) Then
            isAdmin = True
        End If

        Return isAdmin
    End Function
    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Try
            '# Deleting old key
            IO.File.Delete(PathTxt.Text & "rarreg.key")

            '# Write a new key
            IO.File.WriteAllText(PathTxt.Text & "rarreg.key", My.Settings.KeyGen)

            '# Change status
            Status.Text = "Successfuly activated."
            Box.BackColor = Color.Lime
            Status.ForeColor = Color.Lime

        Catch ex As Exception
            '# Change status
            Status.Text = "Activation failed. " & ex.Message
            Box.BackColor = Color.Crimson
            Status.ForeColor = Color.Crimson
        End Try
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        Try
            '# Deleting old key
            IO.File.Delete(PathTxt.Text & "rarreg.key")

            '# Write a new key
            IO.File.WriteAllText(PathTxt.Text & "rarreg.key", My.Settings.defReg)

            '# Change status
            Status.Text = "Successfuly restored back old key."
            Box.BackColor = Color.Lime
            Status.ForeColor = Color.Lime

        Catch ex As Exception
            Status.Text = "Fail with getting back old key. " & ex.Message
            Box.BackColor = Color.Crimson
            Status.ForeColor = Color.Crimson
        End Try
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Process.Start("https://dc.gg/vente")
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Process.Start("https://edditdev.com/")
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub
End Class
