   M S B A M L   `   `   `  ����K  GJaneladeCadastro, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:JaneladeCadastroJaneladeCadastro  5      #    JaneladeCadastro.PopUpExcluir   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:JaneladeCadastro     5      c _MaterialDesignThemes.MahApps, Version=3.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5        � Title$  PopUpExcluirTelefone��5	      $	��300��5
      $	��200��5       � AllowsTransparency$
 True��5      
������    ItimFont#��[  5       � 
ResizeMode$ NoResize=�5       � WindowStartupLocation$ CenterOwner=�5       � WindowStyle$
 None=�5       � 	Resources 5        borderCustom �� 
TargetType �� Property �� Value  	txbCustom % !MaterialDesignFloatingHintTextBox	 �� BasedOn)  #MaterialDesignThemes.Wpf.HintAssist��%  &	       &	 �     7  7   �� 5   
   " ��6%   .�5      ��  � ��$	 244��6&   �� 5       �@��Padding$ 0q�6(   �� 5       � ��$ 36��6'   �� 5       � �� �#1E1B236+   �� 5       �@��CornerRadius$ 10��6-   5      �� 5   
   8	   " ��5       .�5!      ��  � ��$	 230��6&   �� 5"       � ��$ 10,0,0,0q�6'   �� 5#       � ��$ 0q�6(   �� 5$       � ��$ Center=�69   �� 5%       �@ FloatingOffset$ 0,-15&�6I   �� 5&       �@ 
IsFloating$
 True��6E   �� 5'       � ��$ 36��6'   �� 5(       � ��
 ���� 6+   �� 5)       � ��$ 0q�60   �� 5*       � ��
 �����6+   �� 5+       � ��8  6+   �� 5,       � ��$ 14(�6)   5-      5.      .��50      �� ���#111014
 �� CornerRadius$
 10��6"   ._�51   
   �  � RowDefinitions 52      �� 53      $��* �6    �� 54      $
��Auto �6    .+�57      �� $��0��58      $��Center=�59      #��[ 5:      ._�5;      �� -   5         ��Name$ txbIdDigitado��5<         Hint$ Digite o ID para excluir��5=      #��[ 5>      5?      �� 5A      $��1��5B      $��0,0,0,10q�5C      $��Center=�5D       �� Orientation$ 
Horizontal=�5E      .+�5F      �� -   5         ��Name$ 	btnCancel��5G      $��95��5H      $��30��5I      $��0,0,25,0q�5J      $
��Left=�5K      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��5L      ���#910E00$��Cancelar��5O      $��14(�5P      
�������5Q      �� 5S      -   5        $ btnConfirmarId��5T      $��95��5U      $��30��5V      $
��Left=�5W      $ 10��5X      ���#910E00$��	Confirmar��5[      $��14(�5\      
�������5]      5^      5`      5a      5b      