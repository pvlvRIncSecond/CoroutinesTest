Тестовое задание:

Нарисовать интерфейс. Кнопка старт, она же стоп
Два индикатора, которые могут быть либо красными, либо зелеными, либо желтыми. Первоначальный цвет желтый.
Два текстовых поля с первоначальным значением ноль.
Дано две корутины. 
После нажатия Старт запускаются обе корутины. Индикаторый становятся красными. Кнопка переименовывается в Стоп. Одна из корутин становится ведущей. Ее индикатор становится зеленым. Запускается таймер с произвольным числом секунд от 10 до 20. Таймер отсчитывает к нулю и записывает текущее значение в текстовое поле.
Как только таймер доходит до нуля, индикатор корутины становится красным, управление передается другой корутине.
И так по циклу, пока не будет нажата кнопка Стоп. При нажатии кнопки Стоп, индикаторы становятся желтыми, значения в текстовых полях 0, кнопка переименовывается в Старт.