   M S B A M L   `   `   `  ����X  TMyMunicipalServiceApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulls>clr-namespace:MyMunicipalServiceApplication.Views.User_Control0MyMunicipalServiceApplication.Views.User_Control  5      H    BMyMunicipalServiceApplication.Views.User_Control.EventsUserControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Plocal>clr-namespace:MyMunicipalServiceApplication.Views.User_Control     5      .��5	      � $��10q�6     � RowDefinitions  5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $$��Local Events and Announcements��6   $��20(�5      $
��Bold"�5      $��Center=�5      $
��0,10q�5      � 5   
   $��1��6   $��Center=�6   .+�5      �� -   5         ��Name$ 	txtSearch��5      $	��300��5      $��10q�5      .��6H   ��5      �� 5       �� 
TargetType" ��6   .�5       ��  �� Property � �� �� Value
 �����67    �� Triggers 5!      P� 5"       P� Property �@J�IsKeyboardFocused P� Value . . �5#   "   ��  � ��
 �   �6?   �� 5$   "    � ��$  ��69   5%      5'      .��5(   !   5)      5*      �� 5-   
   $��2��6   $��10q�6    �� Padding$ 10q�6*   ���#CEDF9F	 �� CornerRadius$	 5��6L   ���	#FF00712D$��2q�6u   ._�5.      �� 
 �� Orientation$
 
Horizontal=�6   $��Center=�5/      $��Center=�50      .+�52      �� $
 Vertical=�6   $��10q�64   .+�53      �� $��Recommendations��6    $��Center=�67   �� 54      -   5         ��Name$ chkRecommendations��54      $��Enable Recommendations��6;   $��Center=�6\   55      �� 58      $
 Vertical=�6   $��10q�64   .+�59      �� $��Select Date��6    $��Center=�63   �� 5:      $
 
Horizontal=�6!   $��Center=�6:   .+�5;      (  "System.Windows.Controls.DatePicker  -   5          Name$ dpEventDate��5;   %   $	��150��6:   6F   �� 5<      -   5        $��
Clear Date��5<   !   $��75��5=   !   $��5,0,0,0q�5>   !   5?   !   5@      5A      �� 5D      $
 Vertical=�6   $��10q�64   .+�5E      �� $��
Event Type��6    $��Center=�62   �� 5F      -   5         ��Name$ cmbEventType��5F      $	��150��65   .@�5G      �� $��Community Recreation��6'   �� 5H      $��Community Meeting��6'   �� 5I      $��Cultural Meeting��6'   �� 5J      $&�� Government Service Announcements��6'   �� 5K      $��Public Court��6'   �� 5L      $
��None��6'   5M      5N      5O      5P      �� 5S   
   -   5         ��Name$ rtbEventDetails��5S      $��3��5T      $��10q�5U      " �� VerticalScrollBarVisibility$
 Auto=�5V      ���#FFFBE65W      �� 5Z   
   -   5         ��Name$ btnBack��5Z      $
��Back��5[      $��4��5\      $	��100��5]      $��30��5^      $
��Left=�5_      $��Center=�5`      $��10q�5a      ���#FFFBE65c      5d      5e      