   M S B A M L   `   `   `  ����>  :ex1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ex1.Viewex1.View  5      -clr-namespace:ex1.ViewModelex1.ViewModel  5          ex1.View.Graphs   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      R NOxyPlot.Wpf, Version=2.0.0.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0 oxyhttp://oxyplot.org/wpf  5      "localclr-namespace:ex1.View  5      +	viewmodelclr-namespace:ex1.ViewModel  5      $	��555��5   #   .��5      �   � ShowGridLines$
  True��6   
������  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��3* �6   .+�5   
   � $  False��6   $	��Top=�6%   $
��Left=�6=   
������  � RowDefinitions 5      �� 5      $	��18* �6    �� 5      $��* �6    .+�5      �� $��0��6   
������ ��6#   ��  �� Path$ names� �� UpdateSourceTrigger$ PropertyChanged=���5      �� 5       �� 
TargetType" ��6   .�5      -   5        5      5      �� 5      -   5        $��Anomaly��5      $��1��6$   $��Find next anomaly��61   $��15(�6N   
���   �
������ $
��Bold"�6�   $��Bottom=�5       �� 	IsDefault$
 True��6,   {�6=   �� *IsNextAnomaly+ �� Mode$ OneWay=�$ PropertyChanged=�6�   5       � 5)   
   $
  True��6   $��2��6$   
������  5*      �� 5+      $��2* �6    �� 5,      $��4* �6    .+�5.      � $
  True��6   $��0��6(    5/      �� 50      $��* �6'   �� 51      $��* �6'   .+�54        OxyPlot.Wpf.Plot  $��1��6      TitleFontSize$ 10Q�6{   
������ 	   Title	 6+   �� *Correlative+$ PropertyChanged=�$ OneWay=�
   Series
 55        OxyPlot.Wpf.LineSeries  56      $��0, 0, 0, 10q�6�   ��6)   �� *graphes.CorrelativeGraph+$ OneWay=�$ PropertyChanged=�6�   58        5;      $��0��6   $ 10Q�6y   
������ 	 6+   �� *	Attribute+$ OneWay=�$ PropertyChanged=�
 5<        5=      $��0, 0, 0, 10q�6�   ��6)   �� *graphes.AttrGraph+$ OneWay=�$ PropertyChanged=�6�   5?      5@        5B      $��1��6   $	 30 Seconds Graph��6$   
������    Axes 5C        OxyPlot.Wpf.LinearAxis  5D        OxyPlot.Wpf.Axis   Position$ Bottom=�6%      	TickStyle$ Outside=�67      AxislineStyle$	 Dot=�6K     5E      $
 Left=�6%   $ Outside=�65   $ Solid=�6I   
 5G        OxyPlot.Wpf.ScatterSeries  5H      -   5          Name$ pointsG��5H   (   �  �OxyPlot.Wpf.ScatterSeries`1[[OxyPlot.Series.ScatterPoint, OxyPlot, Version=2.0.0.0, Culture=neutral, PublicKeyToken=638079a8f0bd61e9]]   MarkerStroke$ DeepSkyBlue��69      
MarkerFill$ DeepSkyBlue��6T      
MarkerType$ Circle=�6�   ��6m   �� *graphes.DotsGraph+$ OneWay=�$ PropertyChanged=�6�     5I      -   5          Name$ lineG��5I   %      StrokeThickness$ 1Q�64      MarkerStroke$ Black��6H   $��0, 0, 0, 10q�6�   ��6]   �� *graphes.Shape+$ OneWay=�$ PropertyChanged=�6�     5J      -   5        $ anomsG��5J   (   $	 Red��68   $	 Red��6K   $ Circle=�6�   ��6\   �� *graphes.AnomalisGraph+$ OneWay=�$ PropertyChanged=�6�      Annotations 5L         OxyPlot.Wpf.LineAnnotation  5M         OxyPlot.Wpf.PathAnnotation   Color$ Black��6�      Slope 6)   �� *	graphes.X+$ PropertyChanged=�   	Intercept 6j   �� *	graphes.Y+$ PropertyChanged=�   StrokeThickness 6�   �� *graphes.LineThick+$ PropertyChanged=�6  #	  OxyPlot.Wpf.EllipseAnnotation	  5N      !
  OxyPlot.Wpf.ShapeAnnotation 
  Fill$ Transparent��63   
  Stroke$ Black��6F   	  X 6,   �� *	graphes.X+$ PropertyChanged=� 	  Y 6i   �� *	graphes.Y+$ PropertyChanged=���6�   �� *graphes.Radius+$ PropertyChanged=���6�   �� *graphes.Radius+$ PropertyChanged=� 
  StrokeThickness 6U  �� *graphes.CircleThick+$ PropertyChanged=�6�  5P      5R      5U      5V      