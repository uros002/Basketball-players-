   M S B A M L   `   `   `  ����J  FHCIPrviProjekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:HCIPrviProjekatHCIPrviProjekat  5   	   W SNotification.Wpf, Version=8.0.0.0, Culture=neutral, PublicKeyToken=1acac493089262b5_Aclr-namespace:Notification.Wpf.Controls;assembly=Notification.WpfNotification.Wpf.Controls 5   
   !    HCIPrviProjekat.LoginWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:HCIPrviProjekat     5   	   [notificationsAclr-namespace:Notification.Wpf.Controls;assembly=Notification.Wpf     5   
   -   5          � Title$  LoginWindow��5	   	    � WindowStyle$
 None=�5   	   
������  � SizeToContent$ WidthAndHeight=�5   	    � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=�5   #   .��5      �� $	��700��6   $	��350��6   .+�5   
   F� -   5         F�Name$ UIPath��5      ���#0b2838
�������$��0��5      T���� ��    � ����� �� �� ��
� e����� e�     �� �� ��
� ��    	6!   �� 5W   
   $Z��TC:\Users\User\source\repos\HCIPrviProjekat\HCIPrviProjekat\bin\Debug\Images\logo.png��6   $
��Fill=�6n   $	��437��6}    �� Left$	 168��6�   
 �� Top$	 -66��6�   $	��356��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   	 J� Opacity$		 0.1Q�6�   z�5X      V� 5Y      .~�5Z      �� �� 5[      �� 5\      
 �� Angle$
 24.909Q�6&   T� 5]      5^      5`      0  *Notification.Wpf.Controls.NotificationArea  5�   
   -   5          Name$ WindowNotificationArea��5�       K� ZIndex$
 1000��5�         MaxItems$ 3��5�         Position$ 	TopCenter=�5�      ]� 5�   
   $	 150��5�      $ 25��5�      $	��400��5�      $	��300��5�      .+�5�      �� $��50,30,50,15q�5�       �� Orientation$ Vertical=�5�      .+�5�      �� $ Vertical=�6   .+�5�      �� -   5         ��Name$ 
TBUserName��5�      $��40��62   $	��275��6>   $��5 20 5 0q�6J   $��Center=�6\   $��Center=�6�   ���#081c28$		 0.7Q�6�   ���#051117$��2q�6  
�������60  �� 5�      -   5         ��Name$ lbErrorUsername��5�      $��28��65   $�� ��6A   
���  ��6L   5�      �� 5�      $ Vertical=�6   .+�5�      � $��	5 20 5 0 q�6   .+�5�      G� -   5         G�Name$ 
TBPassword��5�   &   $��40��6:   $	��275��6F   $��Center=�6S   $��Center=�6w   ���#081c28$		 0.7Q�6�   ���#051117$��2q�6  
�������6(  �� 5�      -   5         ��Name$ TextBlockPassword��5�   l   $��Password��6$   $��Center=�64   $��Center=�6O   
�����w� �� TextAlignment$ Center=�6�    �� Padding$ 10q�6�   $��12(�6�   $��40��6�   $��75��6�    � Cursor$ IBeam��6(  5�      �� 5�      -   5        $ lbErrorPassword��5�      $��28��65   $�� ��6A   
���  ��$�� 0 0 0 5q�6]   5�      �� 5�      -	   5         ��Name$ BtnLogin��5�      $	��155��5�      $��35��5�      $��	50 0 50 0q�5�      $
 Hand��5�      
���   � � ToolTip$ Login into account��5�      
�������$
��Bold"�5�      $��20(�5�      $��LOG IN��5�      ��5�      �� 5�       �� 
TargetType" ��6    .�5�      ��  �� Property � �� �� Value$ 1q�6@   �� 5�       � ��$ 18(�69   �� 5�       � ��$ Regular"�6;   �� 5�       � ��$ 	Agency FB)�6;   �� 5�       � �� �#e89c316;   �� 5�       � ��
 �����6;    �� Triggers 5�      P� 5�   "    P� Property �@J�IsMouseOver P� Value . . �5�   &   ��  � �� �#ecad546C   �� 5�   &    � ��
 �����6C   �� 5�   &    � ��$ 2q�6H   �� 5�   &    � �� �#ecad546D   5�   #   5�      ��5�      �� 5�       �� 
TargetType" ��6*   .R�5�      ��   �� CornerRadius$  22��6%   $	��150��5�   %   $��35��5�   %   #��z��5�   %   ._�5�   "   �� $��Center=�63   $��Center=�6O   5�      5�      5�      �� 5�      -
   5        $ BtnClose��5�      $
��exit��6+   $	��100��5�      $��20��5�      $��
50 10 50 0q�5�      
������ $��0q�5�      $��15(�5�      $
 Hand��5�      ��5�      �� 5�      " ��6    .�5�      ��  � ��
 �����6;   �� 5�       � ��$ 0q�6@   �� 5�       � ��$ 25(�69   �� 5       � ��$ SemiBold"�6;   �� 5      � ��$ 	Agency FB)�6;   �� 5      � ��
 �����6;    5     P� 5  "    �@J�IsMouseOver . . �5  &   ��  � ��
 �   �6C   �� 5  &    � ��
 �����6C   �� 5  &    � ��$ 2q�6H   �� 5  &    � ��
 �����6D   5	  #   5     5     5     5     5     5     