   M S B A M L   `   `   `  ����>  :Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WpfWpf  5   	       Wpf.Component   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:Wpf     5   	     � Title$  	Component��5   	   $	��450��6   $	��800��6(   .��5	      �� .+�5
   
   � $��1��6    � ColumnDefinitions 5      �� 5      $��* �6#   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ ComponentDataGrid��5   ?      AutoGenerateColumns$ False��6   $��10q�63   $��16(�5         
IsReadOnly$
 True��6-      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6?   $��0��6O      Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width$
 auto 6-      CellTemplate 5      �� 5      .R�5   "   �� 	 �� Orientation$	 
Horizontal=�6-   .+�5   &   �� 
 ��Name$
 del_button_com��6-   -   5        $��25��5   b   $��25��6n   
������ $��0q�5   5   .��5   *   �� $
��auto��60   $��/delete.png��6=   5    '   5!   #   5"      5$      0  *System.Windows.Controls.DataGridTextColumn  5%         Header$+ %Название компонента��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6F   ��  �� Path$ Id�  5&      $ Количество��6)    6=   �� $ Quantity�5+      5-      �� 5.   
   $	 
Horizontal=�6   .+�5/      �� -   5         ��Name$ componentComboBox��5/   a   $��Arial Regular)�6   $
��25px��62   $��	10 0 10 5q�6@   $��15(�6S    �� 
IsEditable$
 True��6|    �� Text$) #Выберите компонент��50       �� DisplayMemberPath$ Name_component��51   2    w� TextPath$ Name_component��52      ��51      �� *
Components+52      �� 53      $��15(�6   $��Arial Regular)�6&   $
��25px��6A   $
��0 15q�6O   $*��$Введите количество:��6]   6z   �� 54      -   5         ��Name$ quantityTextBox��54      $��15(�6/   $��Arial Regular)�6=   $
��25px��6X   $��50��6f   $
��0 10q�6q   �� 55      -   5        $
 AddButton_Component��55      $��10 0 0 0q�62   $��70��6D   $��70��6P   
������ $��0q�57      .��58      �� $"��/Image/icon-plus-2549959.png��6   59      5:      5<      5=      