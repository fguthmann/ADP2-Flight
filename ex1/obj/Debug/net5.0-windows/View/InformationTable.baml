   M S B A M L   `   `   `  ����>  :ex1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ex1.Viewex1.View  5          ex1.View.InformationTable   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:ex1.View     5      .��5      �� 
���   �$��1q�6!   ._�5	   
   �   � ShowGridLines$  False��6    � ColumnDefinitions 5
      �� 5      $��* �6#   �� 5      $��* �6#    � RowDefinitions 5      �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    .+�5      �� $��0��6   $��0��6!   $��	Altimeter��61   $��Stretch=�6E   $��Stretch=�6c   $��Center=�6   $��Center=�6�   $��15(�6�   
�������$��1q�6�   �� 5      -   5         ��Name$ 	Altimeter��5   3   $��0��6   $��1��6#   $��Center=�6F   $��Center=�6h   
������ $��Stretch=�6�   $��Stretch=�6�   
�������$��1q�6�    �� 
IsReadOnly$
 True��6  ��6  �� *VM_Altimeter+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ OneWay=��� 5      $��1��6   $��0��6!   $��Airspeed��61   $��Stretch=�6D   $��Stretch=�6b   $��Center=�6~   $��Center=�6�   $��15(�6�   
�������$��1q�6�   �� 5      -   5        $ Airspeed��5   3   $��1��6   $��1��6#   $��Center=�6E   $��Center=�6g   
������ $��Stretch=�6�   $��Stretch=�6�   
�������$��1q�6�   $
 True��6  ��6  �� *VM_AirSpeed+$ PropertyChanged=�$ OneWay=��� 5      $��2��6   $��0��6!   $��	Direction��61   $��Stretch=�6E   $��Stretch=�6c   $��Center=�6   $��Center=�6�   $��15(�6�   
�������$��1q�6�   �� 5      -   5        $ 	Direction��5   4   $��2��6   $��1��6#   $��Center=�6G   $��Center=�6i   
������ $��Stretch=�6�   $��Stretch=�6�   
�������$��1q�6�   $
 True��6  ��6  �� *VM_Direction+$ PropertyChanged=�$ OneWay=��� 5      $��3��6   $��0��6!   $��Pitch��61   $��Stretch=�6A   $��Stretch=�6_   $��Center=�6{   $��Center=�6�   $��15(�6�   
�������$��1q�6�   �� 5       -   5        $ Pitch��5    3   $��3��6   $��1��6#   $��Center=�6B   $��Center=�6d   
������ $��Stretch=�6�   $��Stretch=�6�   
�������$��1q�6�   $
 True��6  ��6  �� *
VM_Pitch+$ PropertyChanged=�$ OneWay=��� 5"      $��4��6   $��0��6!   $
��Roll��61   $��Stretch=�6@   $��Stretch=�6^   $��Center=�6z   $��Center=�6�   $��18(�6�   
�������$��1q�6�   �� 5#      -   5        $
 Roll��5#   3   $��4��6   $��1��6#   $��Center=�6A   $��Center=�6c   
������ $��Stretch=�6�   $��Stretch=�6�   
�������$��1q�6�   $
 True��6  ��6  �� *	VM_Roll+$ PropertyChanged=�$ OneWay=��� 5%      $��5��6   $��0��6!   $	��Yaw��61   $��Stretch=�6?   $��Stretch=�6]   $��Center=�6y   $��Center=�6�   $��15(�6�   
�������$��1q�6�   �� 5&      -   5        $	 Yaw��5&   3   $��5��6   $��1��6#   $��Center=�6@   $��Center=�6b   
������ $��Stretch=�6�   $��Stretch=�6�   
�������$��1q�6�   $
 True��6   ��6  �� *VM_Yaw+$ PropertyChanged=�$ OneWay=�5(      5)      5+      