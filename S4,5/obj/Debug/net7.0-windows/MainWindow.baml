   M S B A M L   `   `   `  ����@  <Guard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:GuardGuard  5   	       Guard.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Guard     5   	     � Title$!  Стражник - Вход��5   	   $	��450��6!   $	��600��6.    � 
ResizeMode$ NoResize=�6:   .��5	      � .+�5
      �  � ShowGridLines$ False��6    � ColumnDefinitions 5      �� 5      $	��300 �6   6-   �� 5      $	��300 �6   6-   .+�5      �� $��0��6   $��Right=�6!   $��Center=�6=   $��0, 0, 20, 90q�6X   .+�5   
   �� $��22(�6   $��10q�6   .��6*   !Тип Пользователя6<   �� 5   
   $��22(�6   $��10q�6   .��6*   
Логин61   �� 5   
   $��22(�6   $��10q�6   .��6*   Пароль62   �� 5   
   $��22(�6   $��10q�6   .��6*   Секретное слово6;   5      �� 5   
   $��1��6   $
��Left=�6%   $��Center=�6@   $��20, 0, 0, 90q�6[   $	��220��6q   .+�5   
   �� -   5         ��Name$ TypeUser��5      $��22(�6%   $��15q�63   6A   �� 5   
   -   5         ��Name$ Login��5      $��22(�6!   $��15q�6/   6=   �� 5   
   -   5        $
 Pass��5      $��22(�6    $��15q�6.   6<   �� 5   
   -   5        $ 
SecretWord��5      $��22(�6&   $��15q�64   6B   5      5      ]� 5      $��Bottom=�6   $	��100��6+   .+�5      �� .+�5      �� -   5        $	��Top=�5   +   $��Center=�6C   $��18(�6g   $��30��6u   $	��150��6�   $"��Войти в систему��6�   6�   �� 5      $��18(�6   $��Center=�6&   $��10q�6C   .��6O   -+Забыли данные для входа6h   5       5!      5"      5#      