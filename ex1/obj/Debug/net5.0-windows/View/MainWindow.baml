   M S B A M L   `   `   `  ����>  :ex1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ex1ex1  5   	   #clr-namespace:ex1.Viewex1.View  5   	       ex1.MainWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:ex1     5   	   *controlclr-namespace:ex1.View     5   	   -   5          � Title$  
MainWindow��5
   	   $	��650��6   $	��880��6)   .��5      �  � ShowGridLines$ False��6   ��5   
   �� 5       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 1,1&�63   .��5      �  � Color$
 Teal��6    � Offset$	 0.0Q�6,   � 5      $ DarkSeaGreen��6   $	 1.0Q�64   5       � RowDefinitions 5   
   �� 5      $��8* �6   �� 5      $��2* �6   .+�5   
   � $ False��6   $��0��6%   $��1��62    � ColumnDefinitions 5      �� 5      �� 5      $	��320 �6#   .+�5         ex1.View.Graphs  $��Stretch=�6   $
��Left=�69   $
}�True��6T   $��0��6h   � 5       $ False��6   $��1��6)    5!      �� 5"      $��310.029 �6$   �� 5#      .+�5&         ex1.View.InformationTable  $��1��6+   $	��Top=�68      ex1.View.Sliders  5(      $
��Left=�6"   $	��320��6=   5)      5*      � 5+   
   $ False��6   $��1��6%   $��Bottom=�62    5,      �� 5-      $
��387* �6#   �� 5.      $
��493* �6#    50      �� 51      �� 52      .+�54         ex1.View.MediaPlayer     ex1.View.MediaPlayer   Loaded$ MediaPlayer_Loaded��6/   $��0��6"   $��2��6K   �� 55      -   5        $
��Menu��55      $��1��6!   $��Return to menu��6.   $��15(�6H   
���""��
������ $��	ExtraBold"�6�   $��Bottom=�56      $��2��6?   	 �� IsCancel$
	 True��6S   57      58      59      