   M S B A M L   `   `   `  ����  Lasagne    Folder_Sync.Main   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Folder Sync��5   	   $��401.625��6   $��362.769��6.    � WindowStartupLocation$ CenterScreen=�6>   ���	#FFBF0000   WindowStyle1#���   6z    � 	Resources 5        WindowTemplateKey �� 
TargetType ��Name �� Triggers ]� 
Conditions �� Property �� Value	 �� 
TargetName
 �� Property �� Value �� 
TargetType �� Triggers P� Property P� Value��%�  &	       &	  �    7  �� 5   
   " �64   .R�5      �� #��z��6   #��z��6A   #��z��6u   ._�5      � .+�5	      �� .u�5
      �� 5      �� 5      $ WindowResizeGrip��6!   $��Right=�6;   ��.  $y�	Collapsed=�6i   $��Bottom=�6�   5      5       5      ]� 5       5      �� 5       �@�
ResizeMode$ CanResizeWithGrip=�6:   �� 5       �@�WindowState$ Normal=�6;   ./�5      �� $	 WindowResizeGrip��63   
 � y�$ Visible=�6Q   5      5      �� 5   
   " �6%   .�5      �� 
 � ��# � ��6+   �� 5      
 � ��# � ��6+   �� 5      
 � �� 5      �� 5      " �6&   .R�5      �� #��z��6!   #��z��6M   #��z��6�   ._�5       �� .u�5!   "   �� 5"      5#      5$      5&       5'      P� 5(       �@�
ResizeMode$ CanResizeWithGrip=�60   . �5)      �� 
 � ��8   61   5*      5,      5-      .��5.      ��  � UseLayoutRounding . $��0,0,0,0q�6*   $	��Top=�6;   $��Stretch=�6S   $	��370��6q   .+�5/   
   �� -   5        $	��bt1��5/      $��Create a Sync task��6   $��20,80,20,20q�69   $��Center=�6N   $��Center=�6k   $	��130��6�   $��40��6�   $��14(�6�   $��Tahoma)�6�   $��0q�6�    J� Effect 50      3  -System.Windows.Media.Effects.DropShadowEffect  51         Color$ 	#FFE2E0E0��6#      RenderingBias$ Quality=�65      	Direction$	 300Q�6M   53      �� 54   
   -   5        $	��bt2��54      $��Manage Sync tasks��6   $��20q�68   $��Center=�6D   $��Center=�6a   $	��130��6}   $��40��6�   $��14(�6�   $��Tahoma)�6�   $��0q�6�    55        56      $ 	#FFE2E0E0��6#   $ Quality=�65   $	 300Q�6M   58      �� 59   
   -   5        $	��bt3��59      $��Run a Sync task��6   $��20q�66   $��Center=�6B   $��Center=�6_   $	��130��6{   $��40��6�   $��14(�6�   $��Tahoma)�6�   $��0q�6�    5:        5;      $ 	#FFE2E0E0��6#   $ Quality=�65   $	 300Q�6M   5=      5>      5?      