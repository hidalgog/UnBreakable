   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5	   	   @ <Vista, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:VistaVista 5   	      Vista.wpfListadoCliente   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5	   	   localclr-namespace:Vista  5   	     � Title$!  OnBreak - Lista de Clientes��5   	   $��452.333��6-   $��511.334��6>   (   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush
 �   � � WindowStyle$ 
ToolWindow=�6g   ���	#FF88D7F9$
��Bold"�6�    � WindowStartupLocation$ CenterScreen=�6�    � Icon$- 'Imagenes/white_logo_dark_background.jpg��6�    � 
ResizeMode$ NoResize=�6�   .��5      �  � ColumnDefinitions 5   
   �� 5      .+�5   
   �� -   5         ��Name$ btnPasar��5      $��	Traspasar��6#   $
��Left=�67   $��
68,364,0,0q�6R   $	��Top=�6f   $��89��6~   $��Normal"�6�   )   #MahApps.Metro.Controls.ButtonHelper   PreserveTextCase . 	 J� RenderTransformOrigin$	 1.662,0.727&�6�      AccentedSquareButtonStyle#��[  6  &   System.Windows.Controls.DataGrid  5   
   -   5        
  Name$
 dgLista��5      $
��Left=�6$   $��
57,171,0,0q�6?   $	��Top=�6S   $	��173��6k   $	��388��6x   �� 5   
   -   5        $ btnSalir��5      $��Salir��6#   $
��Left=�63   $��360,364,0,0q�6N   $	��Top=�6c   $��75��6{   $��Normal"�6�    . $	 1.662,0.727&�6�   #��[  6  �� 5   
   -   5         ��Name$ 	gbFiltrar��5      $��Filtrar Información��6&   $
��Left=�6C   $��	57,10,0,0q�6^   $	��Top=�6q   $	��144��6�   $	��388��6�   .��5      � $
��Left=�6   $	��110��6.   $��
10,4,0,-34q�6;   $	��Top=�6O   $	��351��6g   .+�5      �� -   5         ��Name$ label��5      $	��Rut��6'   $
��Left=�65   $	��Top=�6P   $��0,1,0,0q�6h   �� 5      -   5        $ label1��5      $��Tipo de Empresa��6(   $
��Left=�6B   $��0,32,0,0q�6]   $	��Top=�6o   �� 5      -   5        $ label2��5      $��	Actividad��6(   $
��Left=�6<   $��0,71,0,0q�6W   $	��Top=�6i   �� 5      -   5         ��Name$ txtFiltroRut��5      *   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Ej. 11.111.111-1��61   $
��Left=�6e   $��23��6�   $��	112,0,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��137��6�   $��Normal"�6�      ClearTextButton . 6�   �� 5      -	   5         ��Name$ 	cbTipoEmp��5      $
��Left=�6.   $��
111,34,0,0q�6I   $	��Top=�6]   $	��138��6u   $��26��6�   $��Normal"�6�   �� 5      -
   5        $ cbActiv��5      $
��Left=�6,   $��
112,71,0,0q�6G   $	��Top=�6[   $	��137��6s   $��Normal"�6   �� 5      -   5        $ btnFiltrarRut��5      $��Filtrar��60   $
��Left=�6B   $��	265,0,0,0q�6]   $	��Top=�6p   $��75��6�   $��Normal"�6�    . $	 1.662,0.727&�6�   #��[  6  �� 5      -   5        $ btnFiltrarTipo��5      $��Filtrar��61   $
��Left=�6C   $��
265,34,0,0q�6^   $	��Top=�6r   $��75��6�   $��Normal"�6�    . $	 1.662,0.727&�6�   #��[  6  �� 5      -   5        $ btnFiltrarAct��5      $��Filtrar��60   $
��Left=�6B   $��
265,69,0,0q�6]   $	��Top=�6q   $��75��6�   $��Normal"�6�    . $	 1.662,0.727&�6�   #��[  6  5       5!      �� 5"   
   -   5        $ btnEliminar��5"      $��Eliminar��6&   $
��Left=�69   $��218,364,0,0q�6T   $	��Top=�6i   $��75��6�   $��Normal"�6�    . $	 1.662,0.727&�6�   #��[  6  5$      5%      