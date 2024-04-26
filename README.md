# 🐸 FrogWindowsFormsApp
## 🎮 🐸 Игра «Лягушки», написанная в процессе изучения технологии Windows Forms и работы с изображениями.

![Изображение](https://github.com/vq11/FrogWindowsFormsApp/blob/master/2024-04-26_19-35-19.png?raw=true)

## 🔧 Техническая часть
* Проект реализован на платформе Windows Forms.
* Для работы с изображениями используется компонент PictureBox.


## 🌆 Работа с изображениями

~~~ csharp
        private void PictureBox_Click(object sender, EventArgs e)
        {
            Swap((PictureBox)sender);
            if(EndGame())
            {
                if(CanBeBetter(Convert.ToInt32(scoreLabel.Text)))
                {
                    MessageBox.Show("Лучший результат!");
                }
                else
                {
                    var result = MessageBox.Show("Можно лучше. Попробовать еще?", "Конец игры", MessageBoxButtons.YesNo);
                    if(result == DialogResult.Yes)
                    {
                        Application.Restart();
                    }
                }
            }
        }

        private void Swap(PictureBox clickedPicture)
        {
            var distance = Math.Abs(clickedPicture.Location.X - emptyPictureBox.Location.X) / emptyPictureBox.Size.Width;

            if (distance > 2)
            {
                MessageBox.Show("Так нельзя");
            }
            else
            {
                var location = clickedPicture.Location;

                clickedPicture.Location = emptyPictureBox.Location;

                emptyPictureBox.Location = location;

                scoreLabel.Text = Convert.ToString(Convert.ToInt32(scoreLabel.Text) + 1);
            }
        }
~~~~
