   M S B A M L   `   `   `  ����L  HEmployee_Training, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Employee_Training.ViewModelsEmployee_Training.ViewModels  5
      +    %Employee_Training.Views.DeptFunctView   5      a ]DevExpress.Xpf.Core.v17.2, Version=17.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ^ ZCaliburn.Micro.Platform, Version=3.2.0.0, Culture=neutral, PublicKeyToken=8e5891231f2ed21f(calhttp://www.caliburnproject.org  5      f bDevExpress.Xpf.Grid.v17.2.Core, Version=17.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa ]DevExpress.Xpf.Grid.v17.2, Version=17.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   5      <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  5      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5	      ;
ViewModels*clr-namespace:Employee_Training.ViewModels  5
      ]	 YDevExpress.Mvvm.v17.2, Version=17.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aAdxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm  	 5      .��5      �� .+�5   
   �   � ColumnDefinitions  5      �� 5      $
��auto �6#   �� 5      $
��auto �6#    � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    .+�5      d� -   5         d�Name$ DeptFunctToggle��5      $��0��64   $��1��6A   $��5q�6Q   $��25��6\   $��85��6h   $
��Left=�6�   ��6s   �� *
ModeSwitch+ d� 	IsChecked 6�   �� *
IsSelected+6�   �� 5       $��1��6   $��1��6%   $��5q�65   $��1��6@   $
��Bold"�6T   Add Department:6w   �� 5#      $��2��6   $��0��6%   $��5q�65   $��Right=�6@   
Dept Name:6h   �� 5$      -   5         ��Name$ DeptName��5$      $��2��6(   $��1��65   $��5q�6E   $
��Left=�6P   $	��200��6k   ��5%      �� *
DeptName+ �� TargetNullValue$  �� �� UpdateSourceTrigger$ PropertyChanged=�{�5&      �� *CanDeptName+�� 5)       �� Orientation$ 
Horizontal=�6   $��3��62   $��1��6?   $��5q�6O   $��Center=�6Z   .+�5*      �� -   5         ��Name$ SaveAll��5*      $��60��6*   $��0 0 5 0q�65   .��6F   Save6L   �� 5,      -   5        $ 
DeleteDept��5,      $��60��6-   $��5 0 5 0q�68   .��6I   Delete6Q   �� 5-      -   5        $ 
CancelDept��5-      $��60��6-   $��5 0 0 0q�68   .��6I   Cancel6Q   5.      5/      � 50   
     51      �� 52      $
��auto �6#   �� 53      $
��auto �6#    57      �� 58      $
��auto �6    �� 59      $
��auto �6    �� 5:      $
��auto �6    �� 5;      $
��auto �6    .+�5?      �� $��0��6   $��0��6%   $��5q�65   $
��Bold"�6@   Select Department:6f   �� 5B      -   5        	 ��Name$$	 AvailableDepartmentsInitialize��5B      $��1��6>   $��0��6K   $��5q�6[   $	��200��6f   $	��250��6s   $	��Top=�6   
 �� DisplayMemberPath$
 DeptName��5C   ?   ��6   �� *AvailableDepartments+ �� SelectedItem 6\   �� *SelectedDepartment+�� 5F      $��2��6   $��0��6%   $��5q�65   $��1��6@   $
��Bold"�6T   
Functions:6r   %  DevExpress.Xpf.Grid.GridControl  5s      -   5          Name$" AvailableFunctionsInitialize��5s      $��3��6D   $��0��6Q   $	��130��6a   $��10q�6n   )  #DevExpress.Xpf.Grid.DataControlBase   ItemsSource 6z   �� *AvailableFunctions+ �� Mode$ TwoWay=�   SelectedItem 5t      �� *SelectedFunction+   Columns. 5u      $  DevExpress.Xpf.Grid.GridColumn  $  DevExpress.Xpf.Grid.ColumnBase   	FieldName$ FunctionName��6!   $  DevExpress.Xpf.Grid.BaseColumn   Header)  #DevExpress.Xpf.Core.ObjectConverter$ Function 6:      	SortOrder$ 	Ascending=�6L      VisibleIndex$ 1��6b      	SortIndex$ 1��6s      Width2  ,DevExpress.Xpf.Grid.GridColumnWidthConverter$	 150 6�     5v      $ RenewalMonths��6!   $ Renewal Months 6;   $ 2��6S   $ 0��6d      View 5w      #  DevExpress.Xpf.Grid.TableView  5x      &	   DevExpress.Xpf.Grid.DataViewBase 	  ShowTotalSummary .  &
   DevExpress.Xpf.Grid.GridViewBase 
  ShowGroupPanel .     	AutoWidth .    NewItemRowPosition$	 Top=�6e     	  RowCellMenuCustomizations 5y      '  !DevExpress.Xpf.Bars.BarButtonItem  5z      -   5         �Name$ deleteRowItem��5z   0   !  DevExpress.Xpf.Bars.BarItem   Content$ Delete 6E   &   DevExpress.Xpf.Grid.GridCommands   DeleteFocusedRow    Command#  Z 6V   5|      5~      5      5�      5�      