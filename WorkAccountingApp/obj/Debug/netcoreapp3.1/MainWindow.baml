   M S B A M L   `   `   `  ����L  HWorkAccountingApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:WorkAccountingAppWorkAccountingApp  5   	   K*clr-namespace:WorkAccountingApp.ViewModelsWorkAccountingApp.ViewModels  5   	   "    WorkAccountingApp.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:WorkAccountingApp     5   	   9vm*clr-namespace:WorkAccountingApp.ViewModels     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  6?     � WindowStyle$  ThreeDBorderWindow=�5	   	    � 
ResizeMode$ NoResize=�5
   	    � WindowStartupLocation$ CenterScreen=�6    � Title$7 1Учет сотрудников по сменам��5   	   $	��400��6,   $	��720��69    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ 
Theme.xaml?�6%   %    5      .��5      ��  �� Orientation$ Vertical=�5   	   
���iii�.+�5   
   o� $��2��6   .@�5      m� $��Файл��6   .@�5      m� $&�� Сохранить на диск��6    m� Command 66   �� *
SaveToJson+m� 5      $$��Сохранить в базу��6    65   �� *	SaveToSql+5      5      �� 5   
   $ Vertical=�5      $��0, 50, 0, 0q�5      $	��150��5      .+�5       �� $ 
Horizontal=�5!      .+�5"      �� $��
Город��5#      $
��Left=�5$      $��	50,40,0,0q�5%      $	��Top=�5&      $	��150��5'      $��15��5(      �� 5)      $��Цех��5*      $
��Left=�5+      $��	80,40,0,0q�5,      $	��Top=�5-      $	��150��5.      �� 5/      $��Сотрудник��50      $
��Left=�51      $��	80,40,0,0q�52      $	��Top=�53      $	��150��54      55      �� 56      $ 
Horizontal=�57      .+�58      �� 	 �� DisplayMemberPath$
	 Name��5;      $
��Left=�5<      $��30��5=      $��	50,20,0,0q�5>      $	��Top=�5?      $	��150��5@      ��59      �� *Cities+
 �� SelectedItem
 5:      �� *SelectedCity+5A      �� 5B      $
	 Name��5E      $
��Left=�5F      $��30��5G      $��	80,20,0,0q�5H      $	��Top=�5I      $	��150��5J      ��5C      �� *Departments+
 5D      �� *SelectedDepartment+5J      �� 5K      $
��Left=�5N      $��30��5O      $��	80,20,0,0q�5P      $	��Top=�5Q      $	��150��5R      ��5L      �� *	Employees+
 5M      �� *SelectedEmployee+5R      5S      5T      �� 5U   
   $ 
Horizontal=�6   $	��160��6.   .+�5V      �� $��Смена:��5W      $
��Left=�5X      $��	50,80,0,0q�5Y      $	��Top=�5Z      $��70��5[      �� 5\      $
��Left=�5^      $��	10,80,0,0q�5_      $	��Top=�5`      $��20��5a      $	��100��5b      ��5]      �� *SelectedShift+5b      �� 5c      $��Бригада:��5d      $
��Left=�5e      $��	30,80,0,0q�5f      $	��Top=�5g      $��70��5h      �� 5i      $
��Left=�5k      $	��Top=�5l      $��	20,80,0,0q�5m      $��20��5n      $	��100��5o      ��5j      �� *SelectedTeam+5o      5p      5q      5r      