   M S B A M L   `   `   `  ����F  BWpfTestDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:WpfTestDemo.MyRouteEventWpfTestDemo.MyRouteEvent  5      S.clr-namespace:WpfTestDemo.MyDependencyProperty WpfTestDemo.MyDependencyProperty  5      C&clr-namespace:WpfTestDemo.MyRouteEventWpfTestDemo.MyRouteEvent  5      L HCustomControls, Version=3.5.4.1139, Culture=neutral, PublicKeyToken=nullG4clr-namespace:CustomControls;assembly=CustomControlsCustomControls 5
          WpfTestDemo.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      <	ClickTime&clr-namespace:WpfTestDemo.MyRouteEvent     5      GMyDependency.clr-namespace:WpfTestDemo.MyDependencyProperty     5      ?MyRouteEvent&clr-namespace:WpfTestDemo.MyRouteEvent     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5	      Musercontrols4clr-namespace:CustomControls;assembly=CustomControls     5
      -   5          � Title$  
MainWindow��5      $	��800��5      $	��450��5       � WindowStartupLocation$ CenterScreen=�5       � 	Resources 5         TextBox.Static.Border �� Color  TextBox.MouseOver.Border  TextBox.Focus.Border  TextBoxStyle1 �� 
TargetType �� Property �� Value-  'System.Windows.Input.KeyboardNavigation �� 
TargetType ��Name	 �� CornerRadius
 J� SnapsToDevicePixels ��Name �� Triggers P� Property P� Value �� 
TargetName �� Triggers ]� 
Conditions �� Property �� Value  TextBox.Static.Border1  TextBox.MouseOver.Border1  TextBox.Focus.Border1  PasswordBoxStyle1  ScrollViewerStyle1 �Name � ColumnDefinitions � RowDefinitions ��Name ��Name �� CanContentScroll �� CanHorizontallyScroll �� CanVerticallyScroll ��Name4  .System.Windows.Automation.AutomationProperties   AutomationId � Cursor �� ScrollableHeight  � Maximum! � Minimum" �� ViewportHeight# �� ViewportSize*$ �� #ComputedVerticalScrollBarVisibility% � Value& �� Mode' �� RelativeSource( �� ScrollableWidth) �� Orientation* �� ViewportWidth,+ �� %ComputedHorizontalScrollBarVisibility 	 PasswordBoxStyle 
 PasswordBoxStyleBase, �� BasedOn  FocusVisual- �� StrokeDashArray  Button.Static.Background  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border  Button.Disabled.Foreground  ButtonStyle1. ��Name  CustomButtonStyle!  CustomControls.CornerButton/   MyCornerRadius  CustomButtonStyle20 �� Path��%�  &	        &	 #     &	 F     &	 i     7   7  7  &	 �    &	 �    &	 �    &	 �    7  7  7  &	 ;    &		      7 
 &	 �    &	 �    &	 �    &	 �    &	 �    &	     &	 4    &	 W    &	 z    &	 �    &	 �    7  7  7  7  7  7  7  7  7  7  &	 �    &	 
    �� 5   
   $ 	#FFABAdB3��68   �� 5   
   $ 	#FF7EB4EA��6;   �� 5   
   $ 	#FF569DE5��67   �� 5   
   " ��6&   .�5      ��  � ��# � ��6+   �� 5       � ��8   6,   �� 5       � ��# � ��6+   �� 5       � ��$ 1q�60   �� 5       �@ TabNavigation$
 None=�6A   �� 5       � ��$
 Left=�6;   �� 5       �@�FocusVisualStyle 61   Z� �� 5       �@J�	AllowDrop . 6*   �� 5       �@��PanningMode$ VerticalFirst=�69   �� 5        �@��IsFlicksEnabled .  67   �� 5!       � �� 5"      �� 5#      " ��6&   .R�5$      �� $ border��5%      #��z��5&      #��z��5'      #��z��5(      $	 3��5)      
 . ._�5+      �� $ PART_ContentHost��5,   !   |�.  $��Hidden=�5.   !   $��Hidden=�5/   !   50       51      P� 52       � {� .  . �53   "   �� $ border��6)    �@J�Opacity$
 0.56Q�6P   54      P� 55       �@J�IsMouseOver . . �56   "   �� $ border��6)   8   � ��6T   57      P� 58       �@J�IsKeyboardFocused . . �59   "   �� $ border��6)   8   � ��6T   5:      5<      5>       5?      ]� 5@       5A      �� 5B      + �@��#IsInactiveSelectionHighlightEnabled . 6S   �� 5C       �@��IsSelectionActive .  6A   ./�5E      ��  �@��SelectionBrush# � /�67   5F      5H      �� 5K   
   $ 	#FFABAdB3��69   �� 5L   
   $ 	#FF7EB4EA��6<   �� 5M   
   $ 	#FF569DE5��68   �� 5N   
   " G�6*   .�5O      ��  �@G�PasswordChar$ *��6-   �� 5P       � ��# � ��6+   �� 5Q       � ��8   6,   �� 5R       � ��# � ��6+   �� 5S       � ��$ 1q�60   �� 5T       �@ TabNavigation$
 None=�6A   �� 5U       � ��$
 Left=�6;   �� 5V       �@�FocusVisualStyle 61   Z� �� 5W       �@J�	AllowDrop . 6*   �� 5X       �@��PanningMode$ VerticalFirst=�69   �� 5Y       �@��IsFlicksEnabled .  67   �� 5Z       � �� 5[      �� 5\      " G�6&   .R�5]      �� $ border��5^      #��z��5_      #��z��5`      #��z��5a      
 . ._�5c      �� $ PART_ContentHost��5d   !   |�.  $��Hidden=�5f   !   $��Hidden=�5g   !   5h       5i      P� 5j       � {� .  . �5k   "   �� $ border��6)    �@J�Opacity$
 0.56Q�6P   5l      P� 5m       �@J�IsMouseOver . . �5n   "   �� $ border��6)   8   � ��6T   5o      P� 5p       �@J�IsKeyboardFocused . . �5q   "   �� $ border��6)   8   � ��6T   5r      5t      5v       5w      ]� 5x       5y      �� 5z      + �@G�#IsInactiveSelectionHighlightEnabled . 6S   �� 5{       �@G�IsSelectionActive .  6A   ./�5}      ��  �@G�SelectionBrush# � /�67   5~      5�      �� 5�   
   " ��6+   .�5�      ��  � �� 5�      �� 5�      " ��6&   .R�5�      � $
 Grid��6   #��z��6-    5�      �� 5�   "   $��* �63   �� 5�   "   $
��Auto �63    5�      �� 5�   "   $��* �60   �� 5�   "   $
��Auto �60   .+�5�      �� $ Corner��5�   !   $��1��5�   !   $��1��5�   !   #��� ��5�   !   �� 5�      $! PART_ScrollContentPresenter��5�   !   $��0��5�   !   $��0��5�   !   #��z��5�   !   # z��5�   !    .   .  #��z��5�   !   #��z��5�   !   �� 5�      $ PART_VerticalScrollBar��5�   !   $��0��5�   !   $��1��5�   !   $ VerticalScrollBar��5�   !   $ Arrow��5�   !   #  z 5�   !   $! 0Q�5�   !   ## z" 5�   !   #y�z$ 5�   !   % 5�   !   �� *VerticalOffset+$& OneWay=�' �� *TemplatedParent+�� 5�      $ PART_HorizontalScrollBar��5�   !   $��1��5�   !   $��0��5�   !   $ HorizontalScrollBar��5�   !   $ Arrow��5�   !   #  z( 5�   !   $! 0Q�5�   !   $) 
Horizontal=�5�   !   ## z* 5�   !   #y�z+ 5�   !   % 5�   !   �� *HorizontalOffset+$& OneWay=�' �� *TemplatedParent+5�      5�      5�       5�      P� 5�       � {� .  . �5�      ��  � ��# � ��63   5�      5�      �� 5�   
   8,   " G�5�      .�5�      ��  � ��
 ���� 6+   �� 5�       � ��$ 1q�60   �� 5�       � ��
 �   �6,   �� 5�       �@G�
CaretBrush
 � � �6+   �� 5�       � ��$ 16(�6)   �� 5�       � ��
 �  ��6+   �� 5�       � ��$ 50��6'   �� 5�       � ��$ 5q�6(   �� 5�       � ��$ Center=�69   �� 5�       � ��$	 350��6)   5�      �� 5�   
   .�5�      ��  � �� 5�      �� 5�      .R�5�      �� $��2q�5�      
 . #��� ��5�      $	- 1 2R�5�      $��1��5�      5�      5�      5�      �� 5�   
   $ 	#FFDDDDDD��6;   �� 5�   
   $ 	#FF707070��67   �� 5�   
   $ 	#FFBEE6FD��6>   �� 5�   
   $ 	#FF3C7FB1��6:   �� 5�   
   $ 	#FFC4E5F6��6<   �� 5�   
   $ 	#FF2C628B��68   �� 5�   
   $ 	#FFF4F4F4��6=   �� 5�   
   $ 	#FFADB2B5��69   �� 5�   
   $ 	#FF838383��6=   �� 5�   
   " ��6%   .�5�      ��  �@�FocusVisualStyle8   61   �� 5�       � ��8  6+   �� 5�       � ��8  6,   �� 5�       � ��# � ��6+   �� 5�       � ��$ 1q�60   �� 5�       � ��$ Center=�6;   �� 5�       � ��$ Center=�69   �� 5�       � ��$ 1q�6(   �� 5�       � �� 5�      �� 5�      " ��6&   .R�5�      �� $ border��5�      #��z��5�      #��z��5�      #��z��5�      
 . ._�5�      �� $. contentPresenter��5   !   #��z��5  !   #��z��5  !   #��z��5  !   |�.  ��. #
 z
 5  !   5      5     P� 5	      �@��IsDefaulted . . �5
  "   �� $ border��6)   # � ��6T    � ��5     P� 5      �@J�IsMouseOver . . �5  "   �� $ border��6)   8   � ��6S   �� 5  "   $ border��6)   8   � ��6T   5     P� 5      � �� . . �5  "   �� $ border��6)   8   � ��6S   �� 5  "   $ border��6)   8   � ��6T   5     P� 5      � {� .  . �5  "   �� $ border��6)   8   � ��6S   �� 5  "   $ border��6)   8   � ��6T   �� 5  "   $ contentPresenter��6)   8 	  � ��6i   5     5     5     5     �� 5!  
   "  6*   .�5"     ��  � ��$ 1q�60   �� 5#      � ��$ Center=�6;   �� 5$      � ��$ Center=�69   �� 5%      � ��$ 1q�6(   �� 5&      � �� 5'     �� 5(     "  6&   .R�5)     �� $ border��5*     #��z��5+     #��z��5,     #��z��5-     #	 z/ 5.     
 . ._�50     �� $. contentPresenter��51  !   #��z��52  !   #��z��53  !   #��z��54  !   |�.  ��. #
 z
 57  !   58      59     P� 5:      �@J�IsMouseOver . . �5;  "   ��  � ��
 �  ��6?   5<     5>     5@     5A     �� 5D  
   " ��6+   .�5E     ��  � ��$ 1q�60   �� 5F      � ��$ Center=�6;   �� 5G      � ��$ Center=�69   �� 5H      � ��$ 1q�6(   �� 5I      � �� 5J     �� 5K     " ��6&   .R�5L     �� $ border��5M     #��z��5N     #��z��5O     #��z��5P     
 . 	 5Q     �� $00 *(usercontrols:CornerButton2.CornerRadius2)�' �� *TemplatedParent+._�5S     �� $. contentPresenter��5T  !   #��z��5U  !   #��z��5V  !   #��z��5W  !   |�.  ��. #
 z
 5Z  !   5[      5\     P� 5]      �@J�IsMouseOver . . �5^  "   ��  � ��
 �  ��6?   5_     5a     5c     5d     5h     .��5i     � -   5        $ RootGrid��5i     .+�5j  
   � -   5        $
 grid��5j      5k     �� 5l     -   5        1 ��Name$1 firstRow��5l      $
��auto �62   �� 5m     -   5        $1 	secondRow��5m      $
��auto �63   �� 5n     -   5        $1 thirdRow��5n      $
��auto �62   �� 5o     -   5        $1 	fourthRow��5o      $
��auto �63   .+�5q     �� -   5        $ scrollViewr��5q     #���  60   .��5r     � $��0��6    5s     �� 5t     $
��auto �6+   �� 5u     $
��auto �6+   �� 5v     $
��auto �6+   .+�5x     �� -	   5        2 ��Name$2 
stackPanel��5y     )   #WpfTestDemo.MyRouteEvent.TimeButton3   
ReportTime$3 stackPanel_ReportTime��5|     $��0��5z     $��10q�5{     4 �� Orientation$4 
Horizontal=�5}     .+�5~       -
   5        5  Name$5 CornerButton��5     $��50��5�     $��自定义依赖属性��5�     $/ 5��5�     #��[ 5�     �� 5�     -   5        6 ��Name$6 CornerButton2��5�     $��50��5�     "  CustomControls.CornerButton27   CornerRadius2$7 5��5�     $��自定义附加属性��5�     #��[ 5�     4   .WpfTestDemo.MyRouteEvent.TimeButtonUserControl  5�     -   5        8  Name$8 myTimeButton��5�  =   $��10q�6S   5�     �� 5�     $��1��5�     $
��10,0q�5�     $4 
Horizontal=�5�     .+�5�     G� -   5        9 G�Name$9 pwdBox��5�     $
��auto��5�     $��30��5�     $��50��5�     $��5q�5�     #��[	 5�     
: � Tag$: 请输入密码��5�     7   1WpfTestDemo.MyDependencyProperty.PassWordAttached
;   Pwd; 5�     �� *
PassWord+$& TwoWay=�< �� UpdateSourceTrigger$< PropertyChanged=�5�     �� 5�     -   5        = ��Name$= pwdText��5�     $
��auto��5�     $��30��5�     $��50��5�     $
��10,0q�5�     $	��5,0q�5�     $��Center=�5�     #���  5�     ��5�     �� *
PassWord+5�     5�     5�     5�     � 5�  
   $	��500��5�     $	��100��5�     $��	0,300,0,0q�5�     $��Center=�5�     $	��Top=�5�      5�     �� 5�     $��* �6#   �� 5�     $
��auto �6#   �� 5�     $��* �6#   .+�5�     �� -   5        $2 TopTips��5�     $��1��5�       CustomControls.TipBar>   	Direction$	> Top=�5�     ?   EnterPostion$
? -150��5�     @   
EnterStyle$@ Vertical��5�     A   HAligin$A Center=�5�     B   MaxTipCount$B 1��5�     C   WaitTime$C 2��5�     5�     5�     5�     