Imports System.Drawing.Imaging

Module modEffect
    Public Function IsKeyframe (ByRef input1 As Bitmap, ByRef input2 As Bitmap,
                                ByVal threshold As Double, ByVal similarity As Double) As Boolean
        Dim diff As Integer = 0
        Dim total As Integer = 0
        For x As Integer = input1.Width/4 To input1.Width*3/4
            For y As Integer = input1.Height/4 To input1.Height*3/4
                total = total + 1
                Dim c1 As Color = input1.GetPixel (x, y)
                Dim c2 As Color = input2.GetPixel (x, y)
                Dim red As Integer = Math.Abs (CInt (c1.R) - CInt (c2.R))
                Dim green As Integer = Math.Abs (CInt (c1.G) - CInt (c2.G))
                Dim blue As Integer = Math.Abs (CInt (c1.B) - CInt (c2.B))
                Dim colorDiff As Double = CDbl (red + green + blue)/CDbl (255*3)
                If colorDiff > threshold Then
                    diff = diff + 1
                End If
            Next
        Next
        If (CDbl (diff)/CDbl (total) > similarity) Then
            Return True
        End If

        Return False
    End Function

    Public Function FadeIn (ByRef input As Bitmap, ByVal startRate As Double,
                            ByVal currentIndex As Integer, ByVal startFrame As Integer, ByVal endFrame As Integer) _
        As Bitmap
        Dim output As New Bitmap (input.Width, input.Height, PixelFormat.Format24bppRgb)
        Dim ratio As Double
        ratio = CDbl (currentIndex - startFrame)/CDbl (endFrame - startFrame)
        Dim r, g, b As Integer
        Dim c As Color
        For x As Integer = 0 To output.Width - 1
            For y As Integer = 0 To output.Height - 1
                c = GetPixel (input, x, y)
                r = c.R*(startRate + (1 - startRate)*ratio)
                g = c.G*(startRate + (1 - startRate)*ratio)
                b = c.B*(startRate + (1 - startRate)*ratio)
                output.SetPixel (x, y, Color.FromArgb (r, g, b))
            Next
        Next

        Return output
    End Function

    Public Function FadeOut (ByRef input As Bitmap, ByVal endRate As Double,
                             ByVal currentIndex As Integer, ByVal startFrame As Integer, ByVal endFrame As Integer) _
        As Bitmap
        Dim output As New Bitmap (input.Width, input.Height, PixelFormat.Format24bppRgb)

        Dim ratio As Double
        ratio = CDbl (currentIndex - startFrame)/CDbl (endFrame - startFrame)
        Dim multiplier As Double
        multiplier = 1 - ratio
        Dim r, g, b As Integer
        Dim c As Color
        For x As Integer = 0 To output.Width - 1
            For y As Integer = 0 To output.Height - 1
                c = GetPixel (input, x, y)
                r = c.R*(endRate + (1 - endRate)*multiplier)
                g = c.G*(endRate + (1 - endRate)*multiplier)
                b = c.B*(endRate + (1 - endRate)*multiplier)
                output.SetPixel (x, y, Color.FromArgb (r, g, b))
            Next
        Next

        Return output
    End Function

    Public Function MotionBlur (ByRef input As Bitmap, ByVal blurCount As Integer,
                                ByVal currentIndex As Integer, ByVal startFrame As Integer, ByVal endFrame As Integer,
                                ByVal newOp As Boolean,
                                ByVal dirname As String) As Bitmap
        
        Dim output As New Bitmap (input.Width, input.Height, PixelFormat.Format24bppRgb)
        
        Dim bufferR(input.Width, input.Height) As Integer
        Dim bufferG(input.Width, input.Height) As Integer
        Dim bufferB(input.Width, input.Height) As Integer

        Dim startIndex As Integer = IIf ((currentIndex - blurCount + 1) < 0, 0, currentIndex - blurCount + 1)
    
        For frameIndex As Integer = startIndex To currentIndex
            
            Dim frame As Bitmap = New Bitmap (dirname & "\f" & CStr (frameIndex) & ".bmp")

            For x As Integer = 0 To input.Width - 1
                For y As Integer = 0 To input.Height - 1
                    
                    bufferR (x, y) = (bufferR (x, y) + frame.GetPixel (x, y).R)
                    bufferG (x, y) = (bufferG (x, y) + frame.GetPixel (x, y).G)
                    bufferB (x, y) = (bufferB (x, y) + frame.GetPixel (x, y).B)
                Next
            Next

        Next

        For x As Integer = 0 To input.Width - 1
            For y As Integer = 0 To input.Height - 1
                
                Dim r As Integer = (bufferR (x, y)/blurCount)
                Dim g As Integer = (bufferG (x, y)/blurCount)
                Dim b As Integer = (bufferB (x, y)/blurCount)
               
                output.SetPixel (x, y, Color.FromArgb (r, g, b))
            Next
        Next

        Return output
    End Function


    Public Function Ripple (ByRef input As Bitmap, ByVal amplitude As Integer, ByVal frequency As Integer,
                            ByVal currentIndex As Integer, ByVal startFrame As Integer, ByVal endFrame As Integer,
                            ByVal startradius As Double) As Bitmap
       
        Dim output As New Bitmap (input.Width, input.Height, PixelFormat.Format24bppRgb)

        Dim center As New PointF (input.Width/2.0#, input.Height/2.0#)
        Dim diagonal As Double = Math.Sqrt (input.Width^2 + input.Height^2)
        Dim ratio As Double = CDbl (currentIndex - startFrame)/CDbl (endFrame - startFrame)
        Dim frameradius As Double = diagonal/2.0#*ratio
        
        For x As Integer = 0 To output.Width - 1
            For y As Integer = 0 To output.Height - 1
                
                Dim radius As Double = Math.Sqrt ((x - center.X)^2 + (y - center.Y)^2)
                Dim angle As Double = Math.Atan2 (y - center.Y, x - center.X)
                
                Dim c As Color
               
                If radius > frameradius Or frameradius = 0 Then
                    c = GetPixel (input, x, y)
                Else
                    Dim offset As Double = amplitude*Math.Sin (2*Math.PI*frequency*(radius/frameradius))
                    Dim newRadius As Double = radius + offset
                    Dim newX As Integer = (newRadius*Math.Cos (angle)) + center.X
                    Dim newY As Integer = input.Height - ((- newRadius*Math.Sin (angle)) + center.Y)
                    c = GetPixel (input, CInt (newX), CInt (newY))
                End If
                
                output.SetPixel (x, y, c)
            Next
        Next

        Return output
    End Function

    Dim _displacement() As Integer = Nothing
    
    Public Function Melt (ByRef input As Bitmap,
                          ByVal useSine As Boolean, ByVal amplitude As Integer, ByVal cycle As Integer,
                          ByVal useRandom As Boolean, ByVal offset As Integer, ByVal period As Integer,
                          ByVal currentIndex As Integer, ByVal startFrame As Integer, ByVal endFrame As Integer,
                          ByVal newOp As Boolean) As Bitmap
        Dim output As New Bitmap (input.Width, input.Height, PixelFormat.Format24bppRgb)

        If newOp Then
            
            ReDim _displacement(input.Width - 1)
            
            If useSine Then
                For x As Integer = 0 To input.Width - 1
                    _displacement (x) = _displacement (x) + Math.Abs (amplitude*Math.Sin (2.0#*Math.PI*cycle*x/(input.Width - 1)))
                Next
            End If
            
            If useRandom Then
                Dim currentOffset As Integer
                Dim currentPeriod As Integer
                Dim sign As Integer
                Dim x As Integer = 0

                While x < input.Width
                    currentPeriod = 1 + Rnd()*(period - 1)
                    If (Rnd() >= 0.5) Then
                        sign = 1
                    Else
                        sign = - 1
                    End If
                    For i As Integer = x To x + currentPeriod - 1
                        currentOffset = currentOffset + sign*Rnd()*offset
                        If currentOffset < 0 Then
                            currentOffset = - 1*currentOffset
                            sign = - 1*sign
                        End If
                        If i < input.Width Then
                            _displacement (i) = _displacement (i) + currentOffset
                        End If
                    Next
                    x = x + currentPeriod
                End While
            End If
        End If

        Dim ratio As Double = ((currentIndex - startFrame)/(endFrame - startFrame))
        For w As Integer = 0 To output.Width - 1
            For h As Integer = 0 To output.Height - 1
                Dim r As Integer = (h - _displacement (w)*ratio)
                w = Bounded(w,0,input.Width-1)
                r = Bounded(r,0,input.Height-1)
                output.SetPixel (w, h, input.GetPixel (w, r))
            Next
        Next
        Return output
    End Function

    
    dim _isInput2() As Boolean
    dim _rate As Double 
    dim _isEnd As Boolean = False
    Public Function Transition (ByRef input1 As Bitmap, ByRef input2 As Bitmap, ByVal type As Integer,
                                ByVal duration As Double, ByVal orientation As Integer,
                                ByVal currentIndex As Integer, ByVal startFrame As Integer, ByVal endFrame As Integer,
                                ByVal newOp As Boolean) As Bitmap
        Dim output As New Bitmap (input1.Width, input1.Height, PixelFormat.Format24bppRgb)
       
        Dim last As Integer = (endFrame - startFrame)*duration
        Dim start As Integer = ((endFrame - startFrame) - last)/2 + startFrame
        Dim percentage As Double = (currentIndex - start)/last
        
        Dim widthBound As Integer = input1.Width - 1
        Dim heightBound As Integer = input1.Height - 1
      
        Select Case type

            'Wipe
            Case 0
                
                Dim condition As Boolean = False
                For x As Integer = 0 To widthBound
                    For y As Integer = 0 To heightBound

                        Select Case orientation
                            Case 0
                                condition = (input1.Width - x)/input1.Width < percentage
                            Case 1
                                condition = x/input1.Width < percentage                                                     
                            Case 2
                                condition = (input1.Height - y)/input1.Height < percentage
                            Case 3
                                condition = y/input1.Height < percentage
                        End Select

                        If condition Then
                            output.SetPixel (x, y,
                                             input2.GetPixel (((x*input2.Width)/input1.Width),
                                                              ((y*input2.Height)/input1.Height)))
                        Else
                            output.SetPixel (x, y, input1.GetPixel (x, y))
                        End If
                    Next
                Next
                
            'dissolve
            Case 1
                      
                If newOp Then
                    ReDim _isInput2(input1.Height - 1)
                    _rate = _isInput2.Length/IIf (last = 0, 1, last)
                    _isEnd = False
                End If
                
                If (currentIndex >= start) Then

                    For i As Integer = 1 To _rate
                        Dim random As New Random
                        Dim index As Integer = random.Next ((input1.Height - 1))
                        Dim max As Integer = 1000
                        Do While _isInput2 (index)
                            max -= 1
                            If (max = 0) Then
                                _isEnd = True
                                Exit Do
                            End If
                            index = random.Next ((input1.Height - 1))
                        Loop
                        _isInput2 (index) = True
                    Next
                End If
                
                If _isEnd Then
                    For t As integer = 0 To heightBound
                        _isInput2 (t) = True
                    Next
                End If
                
                Dim outWidthBound As Integer = output.Width - 1
                Dim outHeightBound As Integer = output.Height - 1
                For x As Integer = 0 To outWidthBound
                    For y As Integer = 0 To outHeightBound
                        If _isInput2 (y) Then
                            output.SetPixel (x, y,
                                             input2.GetPixel ((x*input2.Width)/input1.Width,
                                                              (y*input2.Height)/input1.Height))
                        Else
                            output.SetPixel (x, y, input1.GetPixel (x, y))
                        End If
                    Next
                Next
        End Select

        Return output
    End Function


    
    Public Function Timeshift (ByRef input1 As Bitmap, ByRef input2 As Bitmap, ByVal position As Integer,
                               ByVal region As Integer,
                               ByVal currentIndex As Integer, ByVal startFrame As Integer, ByVal endFrame As Integer,
                               ByVal newOp As Boolean) As Bitmap
        
        Dim output As New Bitmap (input1.Width, input1.Height, PixelFormat.Format24bppRgb)
        Dim cutoff As Integer = input1.Width*position/100

        For x As Integer = 0 To input1.Width - 1
            For y As Integer = 0 To input1.Height - 1
               
                If (x >= cutoff - region/2) And (x <= cutoff + region/2) Then
                    Dim ratio As Double = (x - (cutoff - region/2))/region
       
                    Dim c1 As Color = input1.GetPixel (Bounded(x,0,input1.Width-1), Bounded(y,0,input1.Height-1) )                
                    Dim c2 As Color = input2.GetPixel (Bounded(x,0,input2.Width-1), Bounded(y,0,input2.Height-1) )
                    
                    Dim r, g, b As Integer
                    r = c1.R*(1 - ratio) + c2.R*ratio
                    g = c1.G*(1 - ratio) + c2.G*ratio
                    b = c1.B*(1 - ratio) + c2.B*ratio
                    
                    output.SetPixel (x, y, Color.FromArgb (r, g, b))
                    
                ElseIf (x < cutoff - region/2) Then                    
                    output.SetPixel (x, y, input1.GetPixel (x, y))
                    
                ElseIf (x > cutoff + region/2) Then
                    output.SetPixel (x, y, input2.GetPixel (x, y))
                    
                End If
                
            Next
        Next

        Return output
    End Function

    Private Function Bounded(s,min,max) As Integer
    
        If s < min Then
            s = min
        Elseif s > max then
            s = max
        End If
        Return s
    End Function
    
    ' Get the pixel from the bitmap with the boundary pixels correctly handled
    Private Function GetPixel (ByRef bitmap As Bitmap, ByVal x As Short, ByVal y As Short) As Color
        If x < 0 Then
            x = 0
        ElseIf x > bitmap.Width - 1 Then
            x = bitmap.Width - 1
        End If

        If y < 0 Then
            y = 0
        ElseIf y > bitmap.Height - 1 Then
            y = bitmap.Height - 1
        End If

        GetPixel = bitmap.GetPixel (x, y)
    End Function

    ' Clipping function
    Private Function Clip (ByVal value As Integer) As Integer
        If value > 255 Then
            Return 255
        ElseIf value < 0 Then
            Return 0
        End If
        Return value
    End Function
End Module
