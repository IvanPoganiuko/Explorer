   M S B A M L   `   `   `  ����\  XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   triangleCheckBoxTemplate  �� 
TargetType � 	Resources  Key �� A �� B �� G �� R  	mainColor �� Color F�Name  mainColorBrush �� Stretch	 J� RenderTransformOrigin
 �� Angle �� ScaleX �� ScaleY E� IsClosed E� 
StartPoint �� Point'    !System.Windows.VisualStateManager    VisualStateGroups%   System.Windows.VisualStateGroup   Name   States    System.Windows.VisualState   Name   
Storyboard �� 
TargetName �� TargetProperty	 W� To g� Duration	 �� To�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      :x,http://schemas.microsoft.com/winfx/2006/xaml      5      %�  &	        7  7  7  �� 5      "  ��67    5   
   ���� 5      	mainColor $	 255��6&   $ 50��6.   $ 50��65   $ 50��6<   �� 5      mainColorBrush 8   65   5      .R�5	   
   �� 
������ ._�5
      F� $
 path��6   
������ 8�� $
 Fill=�5      $	 0.5,0.5&�6    z�5      V� 5      .~�5      �� rotateTransfrom��$	
 -45Q�6C   �� 5      $	 0.8Q�6)   $	 0.8Q�66   5      ��5      B� 5      .��5      E� $
 True��6%   $ 0,100&�65   .��5      �� $ 100,100&�6*   �� 5      $ 100,0&�6*   5      5      5       5        5      $ CheckStates��6#   . 5         $ Checked��6"   . 5!      �� .��5"      W� $ rotateTransfrom��6.   $ Angle�5#   B    05$   B   $ 0:0:0.1D�6I   5%      5&        5(      $ 	Unchecked��6"   . 5)      �� .��5*      W� $ rotateTransfrom��6.   $ Angle�5+   B    -455,   B   $ 0:0:0.1D�6K   5-      5.      5/        50      $ CommonStates��6#   . 51        $ Normal��6"   . 52      �� .��53      �� $
 path��6-   $ 
Fill.Color�54   5    	#0055555555   5   $ 0:0:0.3D�6D   56      57        59      $ 	MouseOver��6"   . 5:      �� .��5;      �� $
 path��6-   $ 
Fill.Color�5<   5   8  $ 0:0:0.1D�5=   U   5>      5?      5@      5B      5D      5E      