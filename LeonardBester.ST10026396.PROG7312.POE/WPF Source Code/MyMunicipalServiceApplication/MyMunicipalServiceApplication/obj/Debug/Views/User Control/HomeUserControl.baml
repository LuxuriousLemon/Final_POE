   M S B A M L   `   `   `  ����X  TMyMunicipalServiceApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulls>clr-namespace:MyMunicipalServiceApplication.Views.User_Control0MyMunicipalServiceApplication.Views.User_Control  5      F    @MyMunicipalServiceApplication.Views.User_Control.HomeUserControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Plocal>clr-namespace:MyMunicipalServiceApplication.Views.User_Control     5        � 	Resources  5	         BottomFadeStoryboard �� 
TargetName �� TargetProperty W� From	 W� To g� Duration��%�   &	        �� 5   
   .��5      W� $ BottomFadeRectangle��5      $ Opacity�5      $ 0X�5      $ 1X�5      $ 0:0:2D�5      5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��60 �6    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��2* �6   �� 5       $��1* �6   .+�5%   
   � $��0��6   $��0��6   .+�5&      �� -   5         ��Name$ 	LeftImage��5&      $:��4/Views/User Control/pexels-taryn-elliott-4253928.jpg��6'   $��Stretch=�5'      $��Stretch=�62   $
��Fill=�6N   �� 5)      -   5        	 ��Name$	 BottomFadeRectangle��5)      
�������$��Stretch=�6B   $��Bottom=�6`   $	��100��6{   
 J� Opacity$
 0Q�6�   5*      �� 5-   
   $��0��6   $��1��6   ���	#FF00712D$��1q�6F   $��10q�6Z   $��Center=�6f   ���#FFFBE6._�5.      �� $%��Welcome to your Citizien Portal��6   $��Center=�6?   $��Center=�6\   $��18(�6w   $
��Bold"�6�   5/      � 52   
   $��0��6   $��2��6   .+�53      �� -   5        $ 
RightImage��53      $:��4/Views/User Control/pexels-taryn-elliott-6790327.jpg��6(   $��Stretch=�54      $��Stretch=�62   $
��Fill=�6N   �� 56      -   5        $	 BottomFadeRectangleRight��56      
�������$��Stretch=�6G   $��Bottom=�6e   $	��100��6�   $
 0Q�6�   57      � 5:   
   $��0��6   $��1��6   .+�5;      �� -   5         ��Name$ btnExit��5;      $
��Exit��6&   $	��125��65   $��40��6A   $��Bottom=�6M   $��Stretch=�6h   $��10q�6�   ���	#FFFFFBE6$
��Bold"�6�   5<      � 5?   
   $��2��6   $��1��6   .+�5@      �� -   5        $ btnClearReports��5@      $��Clear Reports��6.   $	��125��6F   $��40��6R   $��Bottom=�6^   $��Stretch=�6y   $��10q�6�   ���	#FFFFFBE6$
��Bold"�6�   6�   5A      � 5D   
   $��1��6   $��1��6   5F      5G      5H      