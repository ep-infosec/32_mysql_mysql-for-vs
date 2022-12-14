
' ++++++++++++++++++++++++++++++++++++++++++++++++++
' This code is generated by a tool and is provided "as is", without warranty of any kind,
' express or implied, including but not limited to the warranties of merchantability,
' fitness for a particular purpose and non-infringement.
' In no event shall the authors or copyright holders be liable for any claim, damages or
' other liability, whether in an action of contract, tort or otherwise, arising from,
' out of or in connection with the software or the use or other dealings in the software.
' ++++++++++++++++++++++++++++++++++++++++++++++++++
' 

Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace $ProjectNamespace$

    Public Class MyDateTimePickerColumn
        Inherits DataGridViewColumn

        Public Sub New()
            MyBase.New(New MyDateTimePickerCell)

        End Sub

        Public Overrides Property CellTemplate As DataGridViewCell
            Get
                Return MyBase.CellTemplate
            End Get
            Set(value As DataGridViewCell)
                If ((Not (value) Is Nothing) _
                            AndAlso Not value.GetType.IsAssignableFrom(GetType(MyDateTimePickerCell))) Then
                    Throw New InvalidCastException("Type must be MyDateTimePickerCell")
                End If
                MyBase.CellTemplate = value
            End Set
        End Property
    End Class

    Public Class MyDateTimePickerCell
        Inherits DataGridViewTextBoxCell

        Public Shared DATE_FORMAT As String = "dd/MM/yyyy, hh:mm"

        Public Sub New()
            MyBase.New()
            Me.Style.Format = DATE_FORMAT
        End Sub

        Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer, ByVal initialFormattedValue As Object, ByVal dataGridViewCellStyle As DataGridViewCellStyle)
            MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle)
            Dim editCtrl As MyDateTimePickerEditingControl = CType(DataGridView.EditingControl, MyDateTimePickerEditingControl)
            If (Value Is Nothing) Then
                editCtrl.Value = CType(DefaultNewRowValue, DateTime)
            Else
                editCtrl.Value = CType(Value, DateTime)
            End If
        End Sub

        Public Overrides ReadOnly Property EditType As Type
            Get
                Return GetType(MyDateTimePickerEditingControl)
            End Get
        End Property

        Public Overrides ReadOnly Property ValueType As Type
            Get
                Return GetType(System.DateTime)
            End Get
        End Property

        Public Overrides ReadOnly Property DefaultNewRowValue As Object
            Get
                Return DateTime.Today
            End Get
        End Property
    End Class

    Public Class MyDateTimePickerEditingControl
        Inherits DateTimePicker
        Implements IDataGridViewEditingControl

        Private _dataGridView As DataGridView

        Private _valueChanged As Boolean = False

        Private _rowIndex As Integer

        Public Sub New()
            MyBase.New()
            Me.Format = DateTimePickerFormat.Custom
            Me.CustomFormat = MyDateTimePickerCell.DATE_FORMAT
        End Sub

        Public Property EditingControlFormattedValue As Object Implements IDataGridViewEditingControl.EditingControlFormattedValue
            Get
                Return Value.ToString(MyDateTimePickerCell.DATE_FORMAT)
            End Get
            Set(value As Object)
                If (TypeOf value Is String) Then
                    Dim _value As DateTime
                    If Not DateTime.TryParse(CType(value, String), _value) Then
                        Value = DateTime.Today
                    Else
                        Value = _value
                    End If
                End If
            End Set
        End Property

        Public Function GetEditingControlFormattedValue(ByVal context As DataGridViewDataErrorContexts) As Object Implements IDataGridViewEditingControl.GetEditingControlFormattedValue
            Return EditingControlFormattedValue
        End Function

        Public Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As DataGridViewCellStyle) Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl
            Font = dataGridViewCellStyle.Font
            CalendarForeColor = dataGridViewCellStyle.ForeColor
            CalendarMonthBackground = dataGridViewCellStyle.BackColor
            CalendarTitleBackColor = dataGridViewCellStyle.BackColor
        End Sub

        Public Property EditingControlRowIndex As Integer Implements IDataGridViewEditingControl.EditingControlRowIndex
            Get
                Return _rowIndex
            End Get
            Set(value As Integer)
                _rowIndex = value
            End Set
        End Property

        Public Function EditingControlWantsInputKey(ByVal key As Keys, ByVal dataGridViewWantsInputKey As Boolean) As Boolean Implements IDataGridViewEditingControl.EditingControlWantsInputKey
            Select Case ((key And Keys.KeyCode))
                Case Keys.Left, Keys.Up, Keys.Down, Keys.Right, Keys.Home, Keys.End, Keys.PageDown, Keys.PageUp
                    Return True
                Case Else
                    Return Not dataGridViewWantsInputKey
            End Select
        End Function

        Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) Implements IDataGridViewEditingControl.PrepareEditingControlForEdit
            ' nothing
        End Sub

        Public ReadOnly Property RepositionEditingControlOnValueChange As Boolean Implements IDataGridViewEditingControl.RepositionEditingControlOnValueChange
            Get
                Return False
            End Get
        End Property

        Public Property EditingControlDataGridView As DataGridView Implements IDataGridViewEditingControl.EditingControlDataGridView
            Get
                Return _dataGridView
            End Get
            Set(value As DataGridView)
                _dataGridView = value
            End Set
        End Property

        Public Property EditingControlValueChanged As Boolean Implements IDataGridViewEditingControl.EditingControlValueChanged
            Get
                Return _valueChanged
            End Get
            Set(value As Boolean)
                _valueChanged = value
            End Set
        End Property

        Public ReadOnly Property EditingPanelCursor As Cursor Implements IDataGridViewEditingControl.EditingPanelCursor
            Get
                Return MyBase.Cursor
            End Get
        End Property

        Protected Overrides Sub OnValueChanged(ByVal e As EventArgs)
            _valueChanged = True
            Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)
            MyBase.OnValueChanged(e)
        End Sub
    End Class
End Namespace