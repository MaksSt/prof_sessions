   M S B A M L   `   `   `  ����I  EStaff_Terminal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Staff_TerminalStaff_Terminal  5   	       Staff_Terminal.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Staff_Terminal     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   $	��225��65   $	��500��6E   .��5	      ]� .+�5
      ��  �� Orientation$ 
Horizontal=�6   $	��Top=�6*   .+�5      �� -   5         ��Name$ 	SearchBox��5      $��15(�6I   $��
5, 0, 0, 0q�6W   $��50��6k   ��6)   �� *SearchBoxValue+6k   �� 5      -   5         ��Name$ Search��5      $��
Поиск��6%   $��15(�65   $��
5, 0, 0, 0q�6C   6W   �� 5      -   5        $��10,0,0,0q�5      .��6>   )'Сохранение изменение6T   �� 5      -   5        $��10,0,0,0q�5      .��69   
Отчёт6@   5      � 5   
    � ShowGridLines$ False��6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��1 �6   �� 5      $	��250 �6   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ DestGrid��5   2      AutoGenerateColumns$
 True��6   62   �� 5      $��1��6   �� 5   
   $��2��6   $��Center=�6%   .+�5      �� .��6   Статус Заявки6#   �� 5      -   5         ��Name$ ComboBoxStatus��5   �   $��30��6l   $	��200��6x   	 �� SelectedItem	 6   �� *'%SelectedItem.СтатусЗаявки+
 �� ElementName$
 DestGrid�� �� Mode$ TwoWay=�6�   �� 5      .��6   
Дата6   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ 
DateSelect��5   u   $��12(�6g      SelectedDate 6   �� *SelectedItem.Дата+$
 DestGrid��$ TwoWay=�6u   �� 5       .��6   Черный список6#   �� 5!      6   5"      5#      5$      5&      