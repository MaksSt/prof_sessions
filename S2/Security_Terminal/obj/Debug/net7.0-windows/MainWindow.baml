   M S B A M L   `   `   `  ����L  HSecurity_Terminal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Security_TerminalSecurity_Terminal  5   	   "    Security_Terminal.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Security_Terminal     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      ]� .+�5
   
   ��  �� Orientation$ 
Horizontal=�6   $	��Top=�6.   .+�5      �� -   5         ��Name$ 	SearchBox��5      $��15(�6I   $��
5, 0, 0, 0q�6W   $��70��6k   ��6)   �� *SearchBoxValue+6k   �� 5      -   5         ��Name$ Search��5      $��
Поиск��6%   $��15(�65   $��
5, 0, 0, 0q�6C   6W   �� 5      -   5        $��10,0,0,0q�5      .��6>   )'Сохранение изменение6T   �� 5      -   5        $��10,0,0,0q�5      .��6;   Данные6C   �� 5      -   5        $��5,0,0,0q�5      .��6;   Заявки6C   5      � 5   
    � ShowGridLines$ False��6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��1 �6#   �� 5      $	��250 �6#   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ DestGrid��5   2      AutoGenerateColumns$
 True��6   62     5      -   5        $ VisGrid��5   2   $
 True��6   $y�	Collapsed=�6C   �� 5      $��1��6   �� 5      -   5         ��Name$ 	EditPanel��5   F   $��2��6   $��Center=�6)   .+�5      �� .��6   0.Разрешение на территорию62   �� 5      -	   5        	 ��Name$	 ComboBoxStatus��5   �   $��30��6z   $	��200��6�   
 �� SelectedItem
 6   �� *;9SelectedItem.РазрешениеНаТерриторию+ �� ElementName$ DestGrid�� �� Mode$ TwoWay=�6�   �� 5       .��6   Время убытия6&   �� 5!      -
   5        $ 
DateSelect��5!   m   $��12(�6_   ��6   ��  �� Path$) #SelectedItem.ВремяУбытия�$ DestGrid��6m   5"      5#      5$      5%      