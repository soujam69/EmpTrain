   M S B A M L   `   `   `  ����L  HEmployee_Training, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Employee_Training.ViewsEmployee_Training.Views  5      +    %Employee_Training.Views.MassTrainView   5      a ]DevExpress.Xpf.Core.v17.2, Version=17.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:Employee_Training.Views     5      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5      .��5
      �� 
���   �$��.5q�6!   $��5q�66     �� Padding$  5q�6A   ._�5   
   �� .+�5      �  � ColumnDefinitions 5      �� 5      $
��auto �6'   �� 5      $
��auto �6'   �� 5      $
��auto �6'    � RowDefinitions 5      �� 5      $��* �6$   �� 5      $��* �6$   .+�5      �� $��0��6   $��0��6)   $��5q�69   $
��Bold"�6D   Training Date:6f   �� 5      $��0��6   $��1��6)   $��5q�69   $
��Bold"�6D   Select Department:6j   �� 5      $��0��6   $��2��6)   $��5q�69   $
��Bold"�6D   Select Function:6h   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ AquiredDatePick��5      $��1��6h   $��0��6u   $��5q�6�      SelectedDate 66   �� *AquiredDate+ �� Mode$ TwoWay=�6�   )  #DevExpress.Xpf.Editors.ComboBoxEdit  5!      $��1��6#   $��1��60   $��5q�6@   $
��Left=�6K   $	��Top=�6f   $	��210��6~   +  %DevExpress.Xpf.Editors.LookUpEditBase   DisplayMember$ DeptName��5"   H      ItemsSource 6   �� *AvailableDepartments+   SelectedItem 6a   �� *SelectedDepartment+  5#      $��1��6#   $��2��60   $��5q�6@   $
��Left=�6K   $	��Top=�6f   $	��210��6~   $ FunctionName��5$   F    6   �� *AvailableFunctions+ 6c   �� *SelectedFunction+5%      � 5(       5)      �� 5*      $��1.75* �6'   �� 5+      $��* �6'   �� 5,      $��1.75* �6'    50      �� 51      $��* �6%   �� 52      $��* �6%   �� 53      $��* �6%   �� 54      $	��100 �6%   .+�58      �� $��0��6   $��0��6)   $
��5 10q�69   $
��Bold"�6G   Available Employees:6o   �� 59      $��0��6   $��2��6)   $
��5 10q�69   $
��Bold"�6G   Selected Employees:6n   �� 5;      -   5        	 ��Name$	 AvailableEmployees��5<   "   $��1��5;      $��0��6(   $��3��68   $��5q�6I   $	��150��6T   $	��Top=�6a   $
��Auto=�6z   
 �� SelectionMode$
 Multiple=�5=   "    �� SelectedItem 5<   >   ��  �� Path$ SelectedEmployeeToAdd�$ TwoWay=���5>      �� 5?      .R�5@      �� ��6)   �� *
FullName+5A      ��5C      �� 5D       �� 
TargetType" ��6!   .�5E      ��  �� Property �@��
IsSelected �� Value 6<   �� $ TwoWay=�$ 
IsSelected�5F      5H      �� 5J      -   5         ��Name$ AddEmployee��5J   s   $��1��6   $��1��6&   $��5q�66   $��25��6A   $	��Add��6M   $	��Top=�6[   6s   �� 5L      -   5        $	 SelectedEmployees��5M      $��1��5L      $��2��6'   $��3��67   $��5q�6H   $	��150��6S   $	��Top=�6`   $
��Auto=�6y   $
 Multiple=�5N       5M   7   �� $ SelectedEmployeeToRemove�$ TwoWay=���5O      �� 5P      .R�5Q      �� ��6'   �� *
FullName+5R      ��5T      �� 5U      " ��6   .�5V      ��  �@��
IsSelected 6:   �� $ TwoWay=�$ 
IsSelected�5W      5Y      �� 5[      -   5        $ RemoveEmployee��5[   �   $��2��6   $��1��6&   $��5,0,5,10q�66   $��25��6I   $��Remove��6U   $��Bottom=�6f   6�   5\      � 5^       5_      �� 5`      $
��auto �6'   �� 5a      $
��auto �6'   �� 5b      $
��auto �6'   �� 5c      $��* �6'    5f      �� 5g      $
��auto �6$   �� 5h      $
��auto �6$   �� 5i      $
��auto �6$   .+�5l      �� $��0��6   $��0��6)   $��5q�69   $
��Bold"�6D   Notes:6^   �� 5m      -   5         ��Name$ Notes��5m      $��1��6)   $��0��66   $��4��6F    �� TextWrapping$
 Wrap=�6Z    �� AcceptsReturn .  �� 
AcceptsTab .  �� 	IsEnabled . " �� VerticalScrollBarVisibility$
 Auto=�5n   K   $��5q�6n   ��5o      �� *Notes+ �� TargetNullValue$  �� �� UpdateSourceTrigger$ PropertyChanged=��� 5p      -   5        $
 Save��5p      $��2��6'   $��0��64   $��75��6D   $��5q�6O   $
��5 10q�6[   .��6i   Save5r      �� 5s      -   5        $ Reset��5s      $��2��6(   $��1��65   $��75��6E   $��5q�6P   $
��5 10q�6\   .��6j   Reset5u      �� 5v      -	   5        $ Cancel��5v      $��2��6)   $��2��66   $��75��6F   $��5q�6Q   $
��5 10q�6]   .��6k   Cancel5x      5y      5z      5{      5|      