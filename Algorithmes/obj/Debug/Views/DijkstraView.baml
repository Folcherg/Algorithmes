   M S B A M L   `   `   `  ����F  BAlgorithmes, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Algorithmes.ModelsAlgorithmes.Models  5      5clr-namespace:Algorithmes.ViewsAlgorithmes.Views  5      $    Algorithmes.Views.DijkstraView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3models clr-namespace:Algorithmes.Models     5      1localclr-namespace:Algorithmes.Views     5        � DataContext  5
      &    Algorithmes.Models.DijkstraModel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $	��200 �6   6+   �� 5      $��30 �6   6*   �� 5      $��25 �6   6*   �� 5      6   .+�5   
   9� $��Paramètres d'entrés��6    9� 
IsExpanded . .��5      �  5      �� 5      6&   �� 5      $��25 �6$   62   �� 5      6&   .+�5          Algorithmes.Views.LinkView  -   5          Name$
 Link��5   !   61   �� 5       $��1��6   ��6&   �� *
AddHandler+��6E   ��  �� ElementName$
 Link�� �� Path$ DataContext�.��6�   Add6�   �� 5"      $��2��6   $��2q�6(   $	��150��63   ��6C   �� *	DataInput+��5#      �� 5$       �� DataType   Algorithmes.Models.Link"  6'   .R�5%      ��  �� Orientation$ 
Horizontal=�6)   .+�5&   "   �� $	��5,0q�6,   ��69   �� *Id1+6P   �� 5'   "   $	��5,0q�6,   ��69   �� *Id2+6P   �� 5(   "   $	��5,0q�6*   ��67   �� *Poids+6P   5)      5*      5,      5-      5.      �� 50   
   $��1��6   $ 
Horizontal=�6"   $��Stretch=�6;   .+�51      �� $��5q�6   $��Point de départ: ��6$   6?   �� 52      $��2q�6   ��6!   �� *Pstart+6;   �� 53      $��15,5,5,5q�6   $��Point de fin: ��6*   6B   �� 54      $��2q�6   ��6!   �� *Pend+69   55      �� 57   
   $��2��6   ��6   �� *
RunHandler+.��6=   Run6B   �� 59   
   -   5         ��Name$ ListView��59       $��3��6   64   5:      5;      