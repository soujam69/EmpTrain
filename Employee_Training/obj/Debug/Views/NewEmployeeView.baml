   M S B A M L   `   `   `  ����L  HEmployee_Training, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Employee_Training.HelpersEmployee_Training.Helpers  5      -    'Employee_Training.Views.NewEmployeeView   5      f bDevExpress.Xpf.Grid.v17.2.Core, Version=17.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa ]DevExpress.Xpf.Grid.v17.2, Version=17.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   a ]DevExpress.Xpf.Core.v17.2, Version=17.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8self'clr-namespace:Employee_Training.Helpers     5      .��5      �� .+�5   
   �   � ColumnDefinitions  5      �� 5      $��* �6#   �� 5      $��* �6#    � RowDefinitions 5      �� 5      $��* �6    �� 5      $��* �6    .+�5      �� $��0��6   $��0��6%   $��5q�65   	Search:6I   �� 5      -   5         ��Name$ SearchEmployees��5      $��1��5      $��0��6$   $��5q�64    �� 
IsEditable .  �� IsTextSearchEnabled .  �� IsDropDownOpen .   �� DisplayMemberPath$ FullName��5   �   ��6*   ��  �� Path$ AvailableEmployees� �� SelectedItem 6Z   �� $ SelectedEmployee�	 �� Mode$	 TwoWay=�6�   d� 5      -   5        
 d�Name$

 Edit��5      $��1��6)   $��1��66   $��5q�6F   $��85��6Q   $
��Left=�6�   ��6\   �� *
ModeSwitch+ d� 	IsChecked 6{   �� *
IsSelected+6�   5      � 5   
     5      �� 5      $��* �6#   �� 5       $
��auto �6#   �� 5!      $��* �6#    5$      �� 5%      $��* �6    �� 5&      $��* �6    �� 5'      $��* �6    �� 5(      $��* �6    �� 5)      $��* �6    .+�5,      �� -   5         ��Name$ FullName��5,      $��0��6*   $��0��67   $��2��6G   $��5 10 5 0q�6[   $
��Left=�6m   $��24(�6�   $
��Bold"�6�   �� 5-      -   5         ��Name$ InActiveChk��5-      $��0��6,   $��2��69   $��5 10 5 5q�6I   $��Right=�6[    5.      �� *Status+$	 TwoWay=�.��6;   
InActive6E   �� 5/      $��First Name:��6   $��1��6,   $��0��69   $��5 10 5 0q�6I   $
��Left=�6[   �� 50      -   5         ��Name$ 	FirstName��50      $��2��6*   $��0��67   $��5q�6G   ��6R   �� *	FirstName+ �� TargetNullValue$  �� �� UpdateSourceTrigger$ PropertyChanged=��� 51      $��
Last Name:��6   $��3��6*   $��0��67   $��5 10 5 0q�6G   $
��Left=�6Y   �� 52      -   5        $ LastName��52      $��4��6(   $��0��66   $��5q�6F   ��6Q   �� *
LastName+$  ��$ PropertyChanged=��� 53      $��
Hire Date:��6   $��1��6*   $��1��67   $��5 10 5 0q�6G   $
��Left=�6Y   (  "System.Windows.Controls.DatePicker  54      -   5          Name$ HireDatePick��54      $��2��60   $��1��6=   $	��5 5q�6M      SelectedDate 6Z   �� *
HireDate+$	 TwoWay=��� 55      $��Review Date:��6   $��3��6,   $��1��69   $��5 10 5 0q�6I   $
��Left=�6[     56      -   5        $ ReviewDatePick��56      $��4��62   $��1��6?   $	��5 5q�6O    6\   �� *
ReviewDate+$	 TwoWay=��� 57      $��Notes:��6   $��1��6&   $��2��63   $��5 10 5 0q�6C   $
��Left=�6U   �� 58      $��Notes:��6   $��1��6&   $��2��63   $��5 10 5 0q�6C   $
��Left=�6U   �� 59      -	   5        $ Notes��59      $��2��6%   $��2��62   $��3��6B    �� TextWrapping$
 Wrap=�6S    �� AcceptsReturn . $��5q�6|    �� 
AcceptsTab .  �� 	IsEnabled . " �� VerticalScrollBarVisibility$
 Auto=�5:   ?   5;      � 5=   
     5>      �� 5?      $��* �6#    5C      �� 5D      $��* �6    �� 5E      $��* �6    �� 5F      $��* �6    �� 5G      $��* �6    .+�5J      �� $��	Position:��6   $��0��6*   $��0��67   $��5 10 5 0q�6G   $
��Left=�6Y   %  DevExpress.Xpf.Grid.GridControl  5O      -
   5          Name$ 	Positions��5O      $��1��61   $��0��6>   $	��130��6N   $��10q�6[   )  #DevExpress.Xpf.Grid.DataControlBase   ItemsSource 6g   �� *	Positions+$	 TwoWay=�   Columns. 5P      $  DevExpress.Xpf.Grid.GridColumn  $  DevExpress.Xpf.Grid.ColumnBase   	FieldName$ TitleId��6!   $  DevExpress.Xpf.Grid.BaseColumn   Header)  #DevExpress.Xpf.Core.ObjectConverter$ Title 65      	SortOrder$ 	Ascending=�6D      VisibleIndex$ 1��6Z      	SortIndex$ 1��6k       Width2  ,DevExpress.Xpf.Grid.GridColumnWidthConverter$	  150 6y   !   EditSettings! 5Q      :	  4DevExpress.Xpf.Editors.Settings.ComboBoxEditSettings	  5R      <
  6DevExpress.Xpf.Editors.Settings.LookUpEditSettingsBase" 
  DisplayMember$" 	TitleName��6R   # 
  ValueMember$# Id��6l   $ 
  ItemsSource$ 63   �� *Titles+6l   5T        5U      $ PositionDate��6!   $ Position Date 6:   $ 2��6Q   $ 0��6b   ! 5V      6  0DevExpress.Xpf.Editors.Settings.DateEditSettings  5W      5Y      %   View% 5[      #  DevExpress.Xpf.Grid.TableView  5\      &   DevExpress.Xpf.Grid.DataViewBase&   ShowTotalSummary& .  &   DevExpress.Xpf.Grid.GridViewBase'   ShowGroupPanel' . (   	AutoWidth( . )   NewItemRowPosition$	) Top=�6d   5^      �� 5`      $��	Training:��6   $��2��6*   $��0��67   $��5 10 5 0q�6G   $
��Left=�6Y     5e      -   5        $ 	Trainings��5e      $��3��61   $��0��6>   $	��130��6N   $��10q�5f       6*   �� *	Trainings+$	 TwoWay=�$ PropertyChanged=�* �� ValidatesOnDataErrors* . . 5g        $ DeptId��6!   $ 
Department 64   ! 5h      	  5i      $# Id��6W   $" DeptName��6h   $ 63   �� *Departments+6h   5k        5l      $ FunctId��6!   $ Function 65   +   CellTemplate+ 5m      �� 5n      .R�5o      )  #DevExpress.Xpf.Editors.ComboBoxEdit  $��PART_Editor��6/   +  %DevExpress.Xpf.Editors.LookUpEditBase,   ValueMember$, Id��5q   -   -   DisplayMember$- FunctionName��6>   .   ItemsSource. 5o   B   �� *View.DataContext.Functions+/   FilterCriteria/ 5p   -   �� *RowData.Row.DeptId+0 �� 	Converter0 )   #Employee_Training.Helpers.Converter  5q   >   5r      5t        5�      $ AcquiredDate��6!   $ Acquired Date 6:   $ 2��6Q   $ 0��6b   ! 5�        5�      5�        5�      $ Status��6!   1   IsSmart1 . $ 3��6C   $ 3��6T   $  75 6b   2   
FixedWidth2 . 6m     5�      $ Notes��6!   1 . $ 4��6B   $ 4��6S   % 5�        5�      & .  ' . ( . $	) Top=�6d   5�      5�      � 5�   
     5�      �� 5�      $
��auto �6#   �� 5�      $
��auto �6#   �� 5�      $
��auto �6#   �� 5�      $��* �6#    5�      �� 5�      $��40 �6    .+�5�      �� -   5        3 ��Name$
3 Save��5�      $��0��6#   $��0��60   $��10 5 5 5q�6@   $	��100��6R   .��6^   Save6d   �� 5�      -   5        $3 Reset��5�      $��0��6$   $��1��61   $	��5 5q�6A   $	��100��6N   .��6Z   Reset6a   �� 5�      -   5        $3 Cancel��5�      $��0��6%   $��2��62   $	��5 5q�6B   $	��100��6O   .��6[   Cancel6c   5�      5�      5�      