   M S B A M L   `   `   `  ����X  TMyMunicipalServiceApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulls>clr-namespace:MyMunicipalServiceApplication.Views.User_Control0MyMunicipalServiceApplication.Views.User_Control  5      T    NMyMunicipalServiceApplication.Views.User_Control.ServiceRequestPageUserControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Plocal>clr-namespace:MyMunicipalServiceApplication.Views.User_Control     5      .��5	      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $	��100 �6   �� 5      $��2* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��Service Request Status��5      $��20(�5      $
��Bold"�5      $��Center=�5      $
��0,10q�5      � 5    
   $��1��6   .+�5!      �� ���	#FF00712D$��2q�6-    �� CornerRadius$ 5��6A    �� Padding$ 10q�6R   $��10q�6_   ���#CEDF9F._�5"      ��  �� Orientation$ 
Horizontal=�6   $
��Left=�66   $��Center=�6Q   .+�5$      �� $��Select Status: ��6    $��Center=�67   $��0,0,10,0q�6R   $
��Bold"�6d   �� 5%      -   5        $��	cmbStatus��5%      $��Center=�60   $��0,0,20,0q�6K   $	��100��6]   .@�5&      �� $��Pending��6'   �� 5'      $��In Progress��6'   �� 5(      $��Complete��6'   �� 5)      $	��Any��6'    �� 
IsSelected . 65   5*      �� 5-      $��Select Priority: ��6    $��Center=�69   $��0,0,10,0q�6T   $
��Bold"�6f   �� 5.      -   5        $��cmbPriority��5.      $��Center=�62   $��0,0,10,0q�6M   $	��100��6_   .@�5/      �� $	��Any��6'    . 65   �� 50      $
��High��6'   �� 51      $��Medium��6'   �� 52      $	��Low��6'   53      54      55      56      �� 59   
   $��2��6   $��10q�6$   .��5;      �� ���	#FF00712D$��2q�6-   ._�5=      �� -   5         ��Name$ UserControlContainer��5=      5>      5?      �� 5B   
   -   5        $��3��5B      $
��Back��6   $	��100��6-   $��30��69   $
��Left=�6E   $��Center=�6`   $��10q�6{   ���#FFFBE66�   5C      5D      