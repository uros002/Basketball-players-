   M S B A M L   `   `   `  ����J  FHCIPrviProjekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:HCIPrviProjekatHCIPrviProjekat  5   	   W SNotification.Wpf, Version=8.0.0.0, Culture=neutral, PublicKeyToken=1acac493089262b5_Aclr-namespace:Notification.Wpf.Controls;assembly=Notification.WpfNotification.Wpf.Controls 5   	   $    HCIPrviProjekat.UserMainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4fa5$http://schemas.fontawesome.io/icons/     5   	   /localclr-namespace:HCIPrviProjekat     5   	   [notificationsAclr-namespace:Notification.Wpf.Controls;assembly=Notification.Wpf     5   	     � Title$  UserMainWindow��5
   	    � WindowStyle$
 None=�5   	   
������  � SizeToContent$ WidthAndHeight=�5   	    � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=�5   	   .��5      � .+�5   
   0  *Notification.Wpf.Controls.NotificationArea  -   5          Name$  WindowNotificationAreaUser��5       K� ZIndex$
 1000��5         MaxItems$ 3��5         Position$ 	TopCenter=�5      �� 5      $
��1000��6   $	��600��6   .+�5   
   F� -   5        	 F�Name$	 	UIPathMWU��5      
�������
���  ��$��2��5      ��5      B� 5      .��5      E� 
 E� 
StartPoint$

 0, 0&�6!   .��5       ��  �� Point$ 0,600&�6&   �� 5!      $ 1000,600&�6&   �� 5"      $ 1000,0&�6&   �� 5#      $	 0,0&�6&   5$      5%      5'      � 5+   
   $
��1000��6   $	��600��6    � RowDefinitions 5,      �� 5-      $��3* �6    �� 5.      $��3* �6    �� 5/      $��3* �6    �� 50      $��2* �6    �� 51      $��* �6     � ColumnDefinitions 53      �� 54      $��* �6#   �� 55      $��* �6#   �� 56      $��* �6#   .+�59      �� $��KK CRVENA ZVEZDA��6   $��0��6/   $��0��6<   $��3��6L   $��Center=�6`   $��50(�6}   $��	Agency FB)�6�   $	��Top=�6�   $��Center=�6�   $��	0 40 0 40q�6�   $
��Bold"�6�   
���  ��6
  &   System.Windows.Controls.DataGrid  5=      -   5          Name$ PlayersDataGrid��5=      $��1��60   $��3��6=   $��3��6N   $��0��6b   $��	10 0 10 0q�6r      
IsReadOnly .    AutoGenerateColumns .  ��. $
��Auto=�6�   $
��Auto=�6
  $��18(�6\  ��6:  �� *	Players+   Columns 5?      4  .System.Windows.Controls.DataGridTemplateColumn  5A      ,  &System.Windows.Controls.DataGridColumn   Header$ Picture��6-      CellTemplate 5B      �� 5C      .R�5D   "   �� $	��100��6G   $	��100��6S   ��6(   �� *SelfPicture+6S   5E      5G        5I      $ Player��6-    5J      �� 5K      .R�5L   "   �� �� 5M   &   -   5        .�5M   I   .�5N   *   �� �6.   �� *
FullName+5P   '   5R   #   5S      5U      0  *System.Windows.Controls.DataGridTextColumn  5W      $ Jersey number��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6@   �� *JerseyNumber+  5X      $ Datum rodjenja��6)    6A   �� *BirthDateToDisplay+5[      �� 5]      -   5         ��Name$ 	BtnLogOut��5]      $��4��6(   $��1��65   $��Center=�6E   $��Center=�6`   $��35��6}   $	��155��6�   $	��0 5q�6�   $��LOG OUT��6�    � Cursor$
 Hand��6�   ��5^      �� 5_       �� 
TargetType" ��6   .�5`      ��  �� Property � �� �� Value$ 1q�6<   �� 5a       � ��$ 25(�65   �� 5b       � ��$ SemiBold"�67   �� 5c       � ��$ 	Agency FB)�67   �� 5d       � ��
 �  ��67   �� 5e       � ��
 �����67    �� Triggers 5f      P� 5g       P� Property �@J�IsMouseOver P� Value . . �5h   "   ��  � ��
 �����6?   �� 5i   "    � ��
 �  ��6?   �� 5j   "    � ��$ 2q�6D   �� 5k   "    � ��
 �  ��6@   5l      5n      ��5p      �� 5q       �� 
TargetType" ��6&   .R�5r      ��  �� CornerRadius$ 22��6!   #��z��5s   !   ._�5t      �� $��Center=�6/   $��Center=�6K   5u      5w      5z      5{      5~      5�      5�      