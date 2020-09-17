Public Class Overwritepopup

    Public Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        MainForm.eng(InputForm.overwriteval) = Convert.ToInt32(InputForm.TextBox2.Text)
        MainForm.mat(InputForm.overwriteval) = Convert.ToInt32(InputForm.TextBox3.Text)
        MainForm.sci(InputForm.overwriteval) = Convert.ToInt32(InputForm.TextBox4.Text)
        Me.Hide()
        InputForm.Hide()

    End Sub ' overwrites the selected index and then returns to the main menu

    Public Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        InputForm.Hide()

    End Sub ' turns off both this and the nput popup return the user to the main menu
End Class