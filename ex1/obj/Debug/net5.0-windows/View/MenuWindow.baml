   M S B A M L   `   `   `  ����>  :ex1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ex1.Viewex1.View  5   	       ex1.View.MenuWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:ex1.View     5   	     � Title$  
MenuWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � ShowGridLines$ False��6    � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��2* �6   �� 5      $	��.5* �6   �� 5      $��2* �6   �� 5      $	��.5* �6   �� 5      $��2* �6   �� 5      $	��.5* �6   �� 5      $
��2.5* �6   �� 5      $	��.5* �6   �� 5      $��2* �6   �� 5      $	��.5* �6   �� 5      $��2* �6   �� 5      .+�5   
   �� $��3��6   $��12��6$   $��/Images/pilot.jpg��66   �� 5    
   $��0��6   $��3��6!   $��Flight Analayzer��65   $��Center=�6M   $��	ExtraBold"�6j   $��40(�6�   
���k���$	��Top=�6�   � 5"   
   $��0��6   $��0��6    5#      �� 5$      $��* �6#   �� 5%      $��* �6#    5'      �� 5(      $��1* �6    �� 5)      $��1* �6    �� 5*      51      �� 5;   
   $��1��6   $��2��6    $�� ��6-   $��Bottom=�68   $��Center=�6Z   $��20(�6~   
���/kU�
������ $��	ExtraBold"�6�   �� 5<   
   -   5         ��Name$ exceptionFLightDrop��5<   N   $��1��6   $��4��6%   $��Center=�63    J� 	AllowDrop$
 True��6�   .+�5=      �� -   5         ��Name$ ExceptionFLight��5=      $'��!Drop/Upload exception flight file��6-   $��25(�6Z   
����� �$��	ExtraBold"�6~   
�������$��1q�6�   
�������$��Stretch=�5>   (   $��Center=�6F   $��Center=�6j   5?      �� 5B   
   -   5        $ dllFile��5B   -   $��1��6   $��6��6    $�� ��6>   $��Bottom=�6I   $��Center=�6k   $��20(�6�   
���/kU�
������ $��	ExtraBold"�6�   �� 5C   
   -   5        $ dllFileDrop��5C   N   $��1��6   $��6��6%   $��Center=�63   $
 True��6{   .+�5D      �� -   5        $ DllBox��5D      $��Drop/Upload dll file��6$   $��25(�6D   
����� �$��	ExtraBold"�6h   
�������$��1q�6�   
�������$��Stretch=�5E   (   $��Center=�6F   $��Center=�6j   5F      �� 5\   
   -   5        $��	RunFlight��5\      $��1��6"   $��8��62   $��
Run Flight��6?   $��25(�6U   
����� �$��	ExtraBold"�6y   
�������$��Center=�5]   (   $��Stretch=�6C    �� 	IsDefault$
 True��6y   �� 5_   
   -   5        $��Close��5_      $��1��6   $��10��6.   $��Close��6<   $��25(�6M   
����� �$��	ExtraBold"�6q   
�������$��Center=�5`   (   $��Stretch=�6C    �� IsCancel$
 True��6u   5b      5c      