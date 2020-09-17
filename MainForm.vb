
Imports System.Math
Public Class MainForm

    Public n As Boolean = False
    Public inputoredit = True ' it will decide for the input popup wich command is being called on
    Public id(0), eng(0), mat(0), sci(0) As Integer ' 0 is used but the first value of the array won't be used anywhere because it is just there to mke sure the array size is not less than 0
    Public searchoredit As Boolean = False ' it decides for the search popup which command is being called on  true is search



    Public Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click ' input button uses an inputform
        inputoredit = True

        n = True
        InputForm.TextBox1.ReadOnly = False ' turns off read only funtcion used in edit
        InputForm.TextBox1.Text = ""
        InputForm.TextBox2.Text = ""
        InputForm.TextBox3.Text = ""
        InputForm.TextBox4.Text = ""
        InputForm.Show() ' opens up input form and focuses on the first input text box
        InputForm.TextBox1.Focus()

    End Sub ' for input

    Public Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If id.GetUpperBound(0) >= 1 Then 'the main code will only work if an input has already occured
            Display.TextBox2.Text = "" ' clears all textboxes
            Display.TextBox3.Text = ""
            Display.TextBox4.Text = ""
            Display.TextBox5.Text = ""
            Display.TextBox6.Text = ""
            Display.TextBox2.Text += "ID" + Environment.NewLine + "_____"
            Display.TextBox3.Text += "English" + Environment.NewLine + "___" 'headings for individual textboses
            Display.TextBox4.Text += "Math" + Environment.NewLine + "___"
            Display.TextBox5.Text += "Science" + Environment.NewLine + "___"

            For i = 1 To id.GetUpperBound(0)


                Display.TextBox2.Text += Environment.NewLine + Convert.ToString(id(i)) ' All the data that was inputted
                Display.TextBox3.Text += Environment.NewLine + Convert.ToString(eng(i))
                Display.TextBox4.Text += Environment.NewLine + Convert.ToString(mat(i))
                Display.TextBox5.Text += Environment.NewLine + Convert.ToString(sci(i))
                Display.TextBox6.Text += Environment.NewLine
            Next

            Display.TextBox3.Text += Environment.NewLine + "_________"
            Display.TextBox4.Text += Environment.NewLine + "_________"
            Display.TextBox5.Text += Environment.NewLine + "_________"
            Display.TextBox6.Text += Environment.NewLine + Environment.NewLine + Environment.NewLine + "Average" + Environment.NewLine + "Maximum" + Environment.NewLine + "Minimum"
            'average max and minimum headings

            Display.TextBox3.Text += Environment.NewLine + Convert.ToString(Average(eng)) ' outputs all the averages, maximums and minimums
            Display.TextBox4.Text += Environment.NewLine + Convert.ToString(Average(mat)) '...on new lines
            Display.TextBox5.Text += Environment.NewLine + Convert.ToString(Average(sci))

            Display.TextBox3.Text += Environment.NewLine + Convert.ToString(Maximum(eng))
            Display.TextBox4.Text += Environment.NewLine + Convert.ToString(Maximum(mat))
            Display.TextBox5.Text += Environment.NewLine + Convert.ToString(Maximum(sci))
            Display.TextBox3.Text += Environment.NewLine + Convert.ToString(Minimum(eng))
            Display.TextBox4.Text += Environment.NewLine + Convert.ToString(Minimum(mat))
            Display.TextBox5.Text += Environment.NewLine + Convert.ToString(Minimum(sci))

            Display.Show()
            Display.Button1.Focus()
        Else
            MessageBox.Show("Please Input a Value First")
        End If
    End Sub ' for display

    Public Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        searchoredit = True
        If id.GetUpperBound(0) >= 1 Then ' the search button opens up a popup to select id if no data has
            'been inputted yet it asks user to input first instead.
            SearchPopup.ListBox1.Items.Clear()

            For i = 1 To id.GetUpperBound(0)
                SearchPopup.ListBox1.Items.Add(id(i))
            Next
            SearchPopup.ListBox1.SelectedIndex = 0
            SearchPopup.Show()
        Else
            MessageBox.Show("Please Input a Value First")
        End If
    End Sub ' for search

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        searchoredit = False
        inputoredit = False

        If id.GetUpperBound(0) >= 1 Then
            SearchPopup.Show()
            SearchPopup.ListBox1.Items.Clear()
            For i = 1 To id.GetUpperBound(0)
                SearchPopup.ListBox1.Items.Add(id(i))
            Next
            SearchPopup.ListBox1.SelectedIndex = 0
        Else
            MessageBox.Show("Please Input a Value First")
        End If

    End Sub ' for edit

    Public Function Average(array() As Integer) ' Finds the average of all data in an array
        Dim avrg As Decimal
        For i = 1 To array.GetUpperBound(0) ' adds up all the numbers into a single variabler
            avrg = avrg + array(i)
        Next

        avrg = avrg / (array.GetUpperBound(0)) ' divides it by the number of numbers present
        Return Math.Round(avrg, 1)
    End Function

    Public Function Maximum(array() As Integer) ' finds maximum out of an array
        Dim max As Integer = 0
        For i = 0 To id.GetUpperBound(0)
            If array(i) > max Then
                max = array(i)
            End If
        Next

        Return max
    End Function

    Public Function Minimum(array() As Integer) ' finds minimum out of the array
        Dim min As Integer = 100 ' 100 is the maximum possible value so...
        For i = 1 To id.GetUpperBound(0)
            If array(i) < min Then
                min = array(i)
            End If
        Next

        Return min
    End Function



End Class

