Module Module1
    Dim name, sname As String
    Dim idnum, telephone As Integer
    Dim msd As Date
    Dim isFound As Boolean
    Dim more As Char

    Sub Main()
        Call memberdata()

    End Sub

    Sub inputdata()

        FileOpen(1, "filemember.txt", OpenMode.Append)
        Do
            Console.Write("Enter the member name: ") : name = Console.ReadLine
            Console.Write("Enter the member ID: ") : idnum = Console.ReadLine
            WriteLine(1, name)
            WriteLine(1, idnum)

            Console.Write("Do you want to enter another record? (Y/N) ")
            more = Console.ReadLine
        Loop Until UCase(more) = "N"
        FileClose(1)
    End Sub
    Sub display()

        FileOpen(1, "filemember.txt", OpenMode.Input)
        While Not EOF(1)
            Input(1, name)
            Input(1, idnum)
            Input(1, telephone)
            Input(1, msd)

            Console.WriteLine("Enter the member name: " & name)
            Console.WriteLine("Enter the member ID: " & idnum)
        End While
        FileClose(1)
    End Sub
    Sub additional()
        FileOpen(1, "filemember.txt", OpenMode.Input)
        FileOpen(2, "filemember2.txt", OpenMode.Output)

        While Not EOF(1)
            idnum = LineInput(1)
            Input(1, name)

            Console.WriteLine("Enter the member name: " & name)
            Console.WriteLine("Enter the member id: " & idnum)

            Console.Write("Enter telephone number: ") : telephone = Console.ReadLine
            Console.Write("Enter the startup date of membership: ") : msd = Console.ReadLine

            WriteLine(2, idnum)
            WriteLine(2, name)
            WriteLine(2, telephone)
            WriteLine(2, msd)
        End While
        FileClose(1)
        FileClose(2)
    End Sub
    Sub memberdata()

        Console.WriteLine("Enter the member name: ")
        name = Console.ReadLine
        Console.WriteLine("Enter the member ID: ")
        idnum = Console.ReadLine

        FileOpen(1, "filemember.txt", OpenMode.Append)
        WriteLine(1, name)
        WriteLine(1, idnum)

        FileClose(1)
        Console.ReadKey()

    End Sub

    Sub search()
        Console.Write("Enter the name of the club member to search for: ") : sname = Console.ReadLine()

        FileOpen(1, "filemember.txt", OpenMode.Input)
        While Not EOF(1)
            name = LineInput(1)
            Input(1, idnum)
            Input(1, telephone)
            Input(1, msd)

            If name = sname Then
                isFound = True
                Console.WriteLine("Enter the member name: " & name)
                Console.WriteLine("Enter the member ID: " & idnum)
                Console.WriteLine("Enter the telephone number: " & telephone)
                Console.WriteLine("Enter the startup date: " & msd)
            End If
        End While
        FileClose(1)

        If Not isFound Then
            Console.WriteLine("Record for the member name " & sname & " couldn't be found...")
        End If
        Console.ReadKey()
    End Sub
End Module
