   M S B A M L   `   `   `  ����>  :ex1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ex1.Viewex1.View  5          ex1.View.MediaPlayer   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:ex1.View     5      .��5	      � 
������   � RowDefinitions  5
   
   �� 5      $��2* �6   �� 5      $��* �6   .+�5   
   �� 
���   �$��1q�6%   � 5   
   $��0��6    � ShowGridLines$ False��6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#   .+�5      � $��0��6   $ False��6#    5      �� 5      $��* �6'   �� 5      $��3* �6'   .+�5      � $��1��6   $ False��6'    5      �� 5       $��* �6+   �� 5!      $��* �6+   �� 5"      $��* �6+   �� 5#      $��* �6+   �� 5$      $��* �6+   �� 5%      $��* �6+   �� 5&      $��* �6+   .+�5(      �� -   5         ��Name$ SlowForwardPlus��5(   -   $��0��6   $��0q�6F   
������ .��5)      �� $H��Bpack://application:,,,/ex1;component/Images/NewSlowForwardPlus.png��6    $��Stretch=�6l   5*      �� 5+      -   5        $ SlowForward��5+   -   $��1��6   $��0q�6C   
������ .��5,      �� $D��>pack://application:,,,/ex1;component/Images/NewSlowForward.png��6    5-      �� 5.      -   5        $
 Play��5.   -   $��2��6   $��0q�6<   
������ .��5/      �� $=��7pack://application:,,,/ex1;component/Images/NewPlay.png��6    50      �� 51      -   5        $ Pause��51   -   $��3��6   $��0q�6=   
������ .��52      �� $>��8pack://application:,,,/ex1;component/Images/NewPause.png��6    53      �� 54      -   5        $
 Stop��54   -   $��4��6   $��0q�6<   
������ .��55      �� $=��7pack://application:,,,/ex1;component/Images/NewStop.png��6    56      �� 57      -   5        $ FastForward��57   -   $��5��6   $��0q�6C   
������ .��58      �� $D��>pack://application:,,,/ex1;component/Images/NewFastForward.png��6    59      �� 5:      -   5        $ FastForwardSuper��5:   -   $��6��6   $��0q�6H   
������ .��5;      �� $H��Bpack://application:,,,/ex1;component/Images/NewFastForwardPlus.png��6    5<      5=      5>      � 5?      $��1��6   $ False��6#    5@      �� 5A      $��* �6'   �� 5B      $��* �6'   �� 5C      $��* �6'   .+�5E      �� $��0��6   $��
Play speed��6(   $��Center=�6=   $��Center=�6_   $��20(�6�   
���   �
������ $��Normal$�6�   $
��Bold"�6�   �� 5F      -   5         ��Name$ 
Play_speed��5F   *   $��1��6   $��Center=�6>   $��Center=�6`   $��Stretch=�6�   $��Stretch=�6�    �� 
IsReadOnly$
 True��6�   
������ 
���   �$��1q�6�   ��6  �� *VM_CurrentSpeed+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ OneWay=� �� StringFormat$ N2���� 5G      -	   5        $
 Time��5G   *   $��2��6   $��Center=�68   $��Center=�6Z   $��Stretch=�6~   $��Stretch=�6�   $
 True��6�   
������ 
���   �$��1q�6�   ��6  �� *VM_TimeString+$ PropertyChanged=�$ OneWay=�5I      5J      �� 5K   
   $��1��6   
���   �$��1q�62   �� 5L   
   	 � Minimum$	 0Q�6   $��1��6o   $��
5, 0, 5, 0q�6|   
 � Maximum
 6   �� *VM_MaxFrame+$ PropertyChanged=�$ OneWay=� � Value 6�   �� *VM_CurrentTime+$ PropertyChanged=�$ TwoWay=�5N      5O      