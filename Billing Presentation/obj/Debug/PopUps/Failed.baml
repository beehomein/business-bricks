   M S B A M L   `   `   `  ����O  KBilling Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Billing_Presentation.PopUpsBilling_Presentation.PopUps  5   	   (    "Billing_Presentation.PopUps.Failed   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:Billing_Presentation.PopUps     5   	     � WindowStyle$
  None=�5   	    � WindowStartupLocation$ CenterScreen=�5	   	    � 
ResizeMode$ NoResize=�5
   	    � Title$ Confirm��5   	   $	��250��6   $	��550��6&    � AllowsTransparency . 
������  � WindowState$ 	Maximized=�5   	    � 	Resources 5         FocusVisual �� Property �� Value	 J� SnapsToDevicePixels
 �� StrokeDashArray  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border   Button.MouseOver.Background1  Button.MouseOver.Border1  Button.Pressed.Background  Button.Pressed.Border 	 Button.Disabled.Background 
 Button.Disabled.Border  Button.Disabled.Foreground  	yesButton �� 
TargetType �� 
TargetType ��Name �� CornerRadius ��Name �� Triggers P� Property P� Value �� 
TargetName   Button.MouseOver.Background2  Button.MouseOver.Border2  noButton��%�  &	        &	 �     &	 �     &	 �     &	     &	 6    &	 Y    &	 |    &	 �    &		 �    &	
 �    &	     &	 +    7   7  7  7  7  7  7  7 	 7 
 7  &	 �    &	     &	 ?    7   7  7  7  7  7  7  7 	 7 
 7  �� 5   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��2q�6$   	 . #��� ��6J   $��1��6�   $	
 1 2R�6�   5      5      5      �� 5   
   $ 	#FFDDDDDD��6;   �� 5   
   $ 	#FF707070��67   �� 5   
   $ 	#FF24B324��6>   �� 5   
   $ 	#FF24B324��6:   �� 5   
   $ 	#FFFF0000��6?   �� 5   
   $ 	#FFFF0000��6;   �� 5   
   $ 	#FFC4E5F6��6<   �� 5    
   $ 	#FF2C628B��68   �� 5!   
   $ 	#FFF4F4F4��6=   �� 5"   
   $ 	#FFADB2B5��69   �� 5#   
   $ 	#FF838383��6=   �� 5$   
   " ��6"   .�5%      ��  �@�FocusVisualStyle8   61   �� 5&       � ��8  6+   �� 5'       � ��8  6,   �� 5(       � ��# � ��6+   �� 5)       � ��$ 1q�60   �� 5*       � ��$ Center=�6;   �� 5+       � ��$ Center=�69   �� 5,       � ��$ 1q�6(   �� 5-       � �� 5.      �� 5/      " ��6&   .R�50      �� $ border��6!   $ 5��61   #��z��6B   #��z��6n   #��z��6�   	 . ._�51      �� $ contentPresenter��6/   |�.  #��z��6[   #��z��6�   ��. #	 z	 6�   #��z��6  52       53      P� 54       �@��IsDefaulted . . �55   "   �� $ border��6@   # � ��6T    � ��56      P� 57       �@J�IsMouseOver . . �58   "   �� $ border��6?   8   � ��6S   �� 59   "   $ border��6@   8   � ��6T   5:      P� 5;       � �� . . �5<   "   �� $ border��6?   8   � ��6S   �� 5=   "   $ border��6@   8   � ��6T   5>      P� 5?       � {� .  . �5@   "   �� $ border��6?   8   � ��6S   �� 5A   "   $ border��6@   8   � ��6T   �� 5B   "   $ contentPresenter��6K   8 	  � ��6i   5C      5E      5G      5H      �� 5I   
   $ 	#FFBEE6FD��6?   �� 5J   
   $ 	#FF3C7FB1��6;   �� 5K   
   " ��6!   .�5L      ��  �@�FocusVisualStyle8   61   �� 5M       � ��8  6+   �� 5N       � ��8  6,   �� 5O       � ��# � ��6+   �� 5P       � ��$ 1q�60   �� 5Q       � ��$ Center=�6;   �� 5R       � ��$ Center=�69   �� 5S       � ��$ 1q�6(   �� 5T       � �� 5U      �� 5V      " ��6&   .R�5W      �� $ border��6!   $ 5��61   #��z��6B   #��z��6n   #��z��6�   	 . ._�5X      �� $ contentPresenter��6/   |�.  #��z��6[   #��z��6�   ��. #	 z	 6�   #��z��6  5Y       5Z      P� 5[       �@��IsDefaulted . . �5\   "   �� $ border��6@   # � ��6T    � ��5]      P� 5^       �@J�IsMouseOver . . �5_   "   �� $ border��6?   8   � ��6S   �� 5`   "   $ border��6@   8   � ��6T   5a      P� 5b       � �� . . �5c   "   �� $ border��6?   8   � ��6S   �� 5d   "   $ border��6@   8   � ��6T   5e      P� 5f       � {� .  . �5g   "   �� $ border��6?   8   � ��6S   �� 5h   "   $ border��6@   8   � ��6T   �� 5i   "   $ contentPresenter��6K   8 	  � ��6i   5j      5l      5n      5o      5p      .��5q      � $	��250��6   $	��550��6   ���	#FFFFEFD7$��Center=�5r       $��Center=�6=    J� Effect 5s   
   3  -System.Windows.Media.Effects.DropShadowEffect  5t         Color$
 #000��6      ShadowDepth$ -2Q�6,      
BlurRadius$ 10Q�6=   5u      .+�5w   
   �� $��Center=�6   $��Center=�62   .+�5x      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   $��Center=�6O   .+�5y      �� -   5         ��Name$ title��5y      $��Center=�6+   $��40(�6F   $
��Bold"�6T   Failed6n   5z      �� 5{      $ 
Horizontal=�6   $��Center=�62   $��Center=�6O   .+�5|      �� -   5         ��Name$ image��5|      $��../assets/fail.png��6'   $��75��6C   $��75��6O   6\   �� 5}      -   5        $ content��5}      $��Center=�6-   $��20(�6H   New Customer Addition Failed6t   5~      �� 5      $ 
Horizontal=�6   $��Right=�62   $��Center=�6N   .+�5�      �� -   5        ���#4a3f35
������� � Cursor$
 Hand��5�   O   $��16(�6]   $
��20,0q�6k   $
��30,5q�6y   #���  6�   .��6�   Close6�   5�      5�      5�      5�      