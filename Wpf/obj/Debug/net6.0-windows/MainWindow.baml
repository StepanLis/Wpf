   M S B A M L   `   `   `  ����>  :Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WpfWpf  5   	       Wpf.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:Wpf     5   	     � Title$  
MainWindow��5   
   $	��510��6   $	��810��6*   $	��510��66   $	��810��6F   .��5	      � ���#81BECE � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��5* �6    � ColumnDefinitions 5   
   �� 5      $	��480 �6   �� 5      $	��320 �6   .+�5   
   �� $��1��6   $��Arial Black)�6$   ���#012E4A$��50(�6R   $��Center=�6`   $��Center=�6}   	LisShop6�   (� 5   
   $��1��6   $��0,74,0,0q�6"   $��2��64   $��Center=�6E   $��Center=�6`   .��5      �� $	��550��6   $	��550��6!   $��10q�6.   .+�5      �� $+��%/Image/free-icon-computer-4249283.png��6   5      5      �� 5   
   $��0��6   $��0��6!   $��Arial Black)�61   ���#012E4A$
��25px(�6_   $��Center=�6o   $��Center=�5      $
��Wrap=�6/   Авторизация6Q   �� 5   
   $��1��6   $��0��6"   ���#036280$��30,60,30,108q�6G   $	��270��6]   .+�5      �� $��
Логин��6   $��25(�6$   ���#4dc4e8$��Arial Regular)�6G   �� 5       -   5         ��Name$ textBox_login��5       $
��25px��6-   $��	10 0 10 5q�6;   $��15(�6N   $��Arial Regular)�6\   �� 5"      $��Пароль��6   $��25(�6%   ���#4dc4e8$��Arial Regular)�6H   G� 5#      -   5         G�Name$ textBox_password��5#      $
��25px��64   $��	10 0 10 5q�6B   $��15(�6U   �� 5$      -   5         ��Name$ textBlock_Error��5$      $��Center=�61   $��25(�6N   
���  ��$y�Hidden=�6q   �� 6�   $5�/Неверный логин или пароль��6�   6�   �� 5%      -   5         ��Name$ button_Enter��5%      $��
Войти��6,   ���#E8EDE7���#378BA4$��Arial Regular)�5&      $��20(�60   $	��399��6Y   5'      5*      5+      