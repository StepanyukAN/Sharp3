   M S B A M L   `   `   `  ����H  DMailSenderGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:MailSenderGUIMailSenderGUI  5   	       MailSenderGUI.TestWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:MailSenderGUI     5   	     � Title$  
TestWindow��5   	   $	��450��6   $	��800��6)    � 	Resources 5	         FocusVisual �� Property �� Value J� SnapsToDevicePixels �� StrokeDashArray  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 ButtonStyle1 �� 
TargetType �� 
TargetType	 A�Name
 ��Name �� Triggers P� Property P� Value �� 
TargetName��%n  &	        &	 �     &	 �     &	 �     &	     &	 6    &	 Y    &	 |    &	 �    &		 �    &	
 �    7   7  7  7  7  7  7  7  7  7 	 �� 5
   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��2q�6$    . #��� ��6J   $��1��6�   $	 1 2R�6�   5      5      5      �� 5   
   $ 	#FFDDDDDD��6;   �� 5   
   $ 	#FF707070��67   �� 5   
   $ 	#FFBEE6FD��6>   �� 5   
   $ 	#FF3C7FB1��6:   �� 5   
   $ 	#FFC4E5F6��6<   �� 5   
   $ 	#FF2C628B��68   �� 5   
   $ 	#FFF4F4F4��6=   �� 5   
   $ 	#FFADB2B5��69   �� 5   
   $ 	#FF838383��6=   �� 5   
   " ��6%   .�5      ��  �@�FocusVisualStyle8   61   �� 5       � ��8  6+   �� 5        � ��8  6,   �� 5!       � ��# � ��6+   �� 5"       � ��$ 1q�60   �� 5#       � ��$ Center=�6;   �� 5$       � ��$ Center=�69   �� 5%       � ��$ 1q�6(   �� 5&       � �� 5'      �� 5(      " ��6&   .R�56      � #��z��6   .+�57      A� $	 border��6&   #��z��58   &   #��z��59   &   #��z��5:   &   �� 5;      $
 contentPresenter��6/   |�.  #��z��5=   /   $	��5,5q�5>   /   ��. # z 5@   /   #��z��5A   /   5B       5C      P� 5D       �@��IsDefaulted . . �5E   "   �� $ border��6;   # � ��6O    � ��5F      P� 5G       �@J�IsMouseOver . . �5H   "   �� $ border��6;   8   � ��6O   �� 5I   "   $ border��6;   8   � ��6O   5J      P� 5K       � �� . . �5L   "   �� $ border��6;   8   � ��6O   �� 5M   "   $ border��6;   8   � ��6O   5N      P� 5O       � {� .  . �5P   "   �� $ border��6;   8   � ��6O   �� 5Q   "   $ border��6;   8   � ��6O   �� 5R   "   $ contentPresenter��6K   8 	  � ��6i   5S      5U      5W      5X      5[      .��5\      � .+�5]   
   �� $	��Top=�6   $
��Left=�6)   $��Button��6D   #��[
 5^      $��35��67   $	��105��6C   5_      5`      