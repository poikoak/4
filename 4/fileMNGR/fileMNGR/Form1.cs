using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fileMNGR
{
    public partial class Form1 : Form
    {
        private Bitmap bitmap;
        private ImageList imglist;
        string currentFolderPath = "";
               bool copiedToClipboard;
        public Form1()
        {
            InitializeComponent();

            try
            {
                // Настойка listView для показа файлов
                fileView.View = View.Details;
                fileView.SmallImageList = new ImageList();
                fileView.LargeImageList = new ImageList();

                fileView.LargeImageList.ImageSize = new Size(48, 48);
                fileView.LargeImageList.Images.Add(Bitmap.FromFile("note11.ico"));
                fileView.SmallImageList.Images.Add(Bitmap.FromFile("note11.ico"));

                fileView.Columns.Add("File Name", 120, HorizontalAlignment.Left);
                fileView.Columns.Add("Data", 100, HorizontalAlignment.Center);
                fileView.Columns.Add("Size", 60, HorizontalAlignment.Center);

                // Создание списка изображений 
                imglist = new ImageList();

                // Добавление иконок в список изображений
                imglist.Images.Add(Bitmap.FromFile("CLSDFOLD.ICO"));
                imglist.Images.Add(Bitmap.FromFile("OPENFOLD.ICO"));
                imglist.Images.Add(Bitmap.FromFile("NOTE11.ICO"));
                imglist.Images.Add(Bitmap.FromFile("NOTE12.ICO"));
                imglist.Images.Add(Bitmap.FromFile("Drive01.ico"));

                // Установка списка загруженных картинок для listView
                dirTree.ImageList = imglist;

                // Переменная для стандартного рисунка(черный квадрат), который будет
                // показываться тогда когда файл не является рисунком
                bitmap = (Bitmap)Bitmap.FromFile("nopicture.bmp");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при работе со списком изображений", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            // Настройка дерева папок
            // Метод для получения списка логических дисков(Доступных дисков)
            DriveInfo[] drives = DriveInfo.GetDrives();

            // Перебор списка дисков
            foreach (var drive in drives)
            {
                // Если диск доступен, добавляем его
                if (drive.IsReady == true)
                {
                    // Создание конкретного узла и назначение иконок
                    TreeNode node = new TreeNode(drive.Name, 4, 4);
                    // Добавили готовый узел к дереву	
                    dirTree.Nodes.Add(node);

                    // Заполнение узлов с дисками
                    FillByDirectories(node);
                }
            }
        }
        // Метод для заполнения узлов дерева содержимым каталога	
        private void FillByDirectories(TreeNode node)
        {
            try
            {
                // В node.FullPath - находится полный путь к ветке
                DirectoryInfo dirinfo = new DirectoryInfo(node.FullPath);

                // Получение информации о каталогах
                DirectoryInfo[] dirs = dirinfo.GetDirectories();

                // Обработка информации
                foreach (DirectoryInfo dir in dirs)
                {
                    if (dir.Exists)
                    {
                        TreeNode tree = new TreeNode(dir.Name, 0, 1);
                        node.Nodes.Add(tree);
                    }
                }

            }
            // Исключение будет генерироваться  например для дисковода, если там нет
            // диска	
            catch { }
        }

        /// <summary>
        /// Метод запускается ДО открытия узловой ветки дерева
        /// </summary>
        /// <param name="sender">Ссылка на дерево</param>
        /// <param name="e">Параметры метода</param>
        private void dirTree_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            // Запрет постоянной перерисовки дерева во время добавления элементов
            dirTree.BeginUpdate();

            // Добавление элементов в дерево
            try
            {
                // Перебор всех дочерних узлов для узла, который разворачивается по нажатию "+"
                foreach (TreeNode node in e.Node.Nodes)
                {
                    FillByDirectories(node);
                }
            }
            catch { }

            // возврат режима обычного обновления дерева (сразу вызывает перерисовку дерева)
            dirTree.EndUpdate();
        }

        private void dirTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                currentFolderPath = e.Node.FullPath;
                FillByFiles(e.Node.FullPath);
            }
            catch (Exception ex)
            { }
        }

        // заполнение listView файлами
        private void FillByFiles(string path)
        {
            fileView.BeginUpdate();

            fileView.Items.Clear();

            DirectoryInfo dirinfo = new DirectoryInfo(path);
            toolStripStatusLabel1.Text = path;

            // Получение информации о файлах
            FileInfo[] files = dirinfo.GetFiles();

            // Обработка информации
            fileView.LargeImageList.Images.Clear();
            fileView.SmallImageList.Images.Clear();
            int iconindex = 0;
            fileView.LargeImageList.Images.Add(Bitmap.FromFile("note11.ico"));
            fileView.SmallImageList.Images.Add(Bitmap.FromFile("note11.ico"));

            // Перебрать все файлы по определённому пути и показать из в listView
            foreach (FileInfo file in files)
            {
                ListViewItem item = new ListViewItem(file.Name);
                item.Tag = file.FullName.Substring(0, path.LastIndexOf('\\'));

                // Получить иконку для текущего файла

                Icon icon = Icon.ExtractAssociatedIcon(file.FullName);
                // Добавить эту иконку в список картинок
                fileView.LargeImageList.Images.Add(icon);
                fileView.SmallImageList.Images.Add(icon);

                iconindex++;

                // Указать номер иконки для listView
                item.ImageIndex = iconindex;

                // Добавить пукт в listView
                item.SubItems.Add(file.LastWriteTime.ToString());
                item.SubItems.Add(file.Length.ToString());
                fileView.Items.Add(item);
            }

            fileView.EndUpdate();
        }

       

        private void createFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //создаем абсолютно пустой файл без расширения
            string name = @"\New file";
            string current = name;
            int i = 0;
            while (File.Exists(currentFolderPath + current))
            {
                i++;
                current = String.Format("{0} {1}", name, i);
            }
            using (File.Create(currentFolderPath + current)) ;
            FillByFiles(currentFolderPath);
        }
    
        private void deleteFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete files?", "Deleting files", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //удаляем выделенные файлы
                for (int i = 0; i < fileView.SelectedItems.Count; i++)
                {
                    //проверяем, является ли выделенный элемент  папкой
                    string folderPath = currentFolderPath + @"\" + fileView.SelectedItems[i].Text;
                    FileAttributes attr = File.GetAttributes(folderPath);
                    if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                        Directory.Delete(folderPath);

                    //проверяем, является ли выделенный элемент файлом
                    if (File.Exists((string)fileView.SelectedItems[i].Tag))
                        File.Delete((string)fileView.SelectedItems[i].Tag);
                }
                FillByFiles(currentFolderPath);
            }
        }

        private void fileView_ItemSelectionChanged_1(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            toolStripStatusLabel2.Text = $"    Selected elements: {fileView.SelectedItems.Count.ToString()}";
        }

        //перетаскивание ил фаилвюв
        private void fileView_MouseDown(object sender, MouseEventArgs e)
        {
            // Если есть выделенные строки
            if (fileView.SelectedItems.Count != 0)
            {
                //получить Tag, который записан для каждого Item в listView, и который содержит в себе полный путь к файлу
                string str = (string)fileView.SelectedItems[0].Tag;

                //создать контейнер для хранения данных
                DataObject data1 = new DataObject();

                //положить содержимое выделенной в списке строки
                StringCollection col = new StringCollection();
                col.Add(str);
                data1.SetFileDropList(col);

                //если выделено имя файла картинки - положить картинку в контейнер
                string ext = Path.GetExtension(str);
                if (ext == ".bmp" || ext == ".jpg" || ext == ".gif" || ext == ".png")
                {
                    Image img = Bitmap.FromFile(str);
                    data1.SetImage(img);
                }

                //НАЧАТЬ перетаскивание програмно
                DragDropEffects dde = DoDragDrop(data1, DragDropEffects.Copy);
            }
        }

        private void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            //если перетаскивается картинка
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                pictureBox1.Visible = true;
                Image img = (Image)e.Data.GetData(DataFormats.Bitmap);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Image = img;
            }
            else if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] str = (string[])e.Data.GetData(DataFormats.FileDrop);
                string txt = File.ReadAllText(str[0]);
                textBox1.Text = txt;
                pictureBox1.Visible = false;
            }
        }

        private void pictureBox1_DragEnter(object sender, DragEventArgs e)
        {

            if ((e.AllowedEffect & DragDropEffects.Copy) != 0)
                e.Effect = DragDropEffects.Copy;
        }
        public void copyPathToClipboard()
        {
            //заполняем массив строк, которые содержат в себе пути к выделенным файлам
            string[] path = new string[fileView.SelectedItems.Count];
            for (int i = 0; i < fileView.SelectedItems.Count; i++)
            {
                path[i] = (string)fileView.SelectedItems[i].Tag;
            }
            //помещаем данный массив в буфер обмена
            StringCollection str = new StringCollection();
            str.AddRange(path);
            Clipboard.SetFileDropList(str);
        }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copyPathToClipboard();
            copiedToClipboard = true;
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                IDataObject obj = Clipboard.GetDataObject();
                if (obj.GetDataPresent(DataFormats.FileDrop))
                {
                    //получаем список путей к файлам из буфера обмена
                    StringCollection files = Clipboard.GetFileDropList();

                    //копируем файлы в текущую папку
                    //путь к текущей папке хранится в currentFolderPath (ранее записан в момент нажатия на элемент treeView1)
                    foreach (string file in files)
                    {
                        string destname = Path.GetFileName(file);
                        if (!File.Exists($@"{currentFolderPath}\{destname}"))
                        {
                            //если была нажата кнопка копирования, то копируем файлы
                            //если - нет, то перемещаем
                            if (copiedToClipboard == true)
                                File.Copy(file, $@"{currentFolderPath}\{destname}");
                            else if (copiedToClipboard == false)
                                File.Move(file, $@"{currentFolderPath}\{destname}");
                        }
                        else
                            MessageBox.Show($"{destname} is already exist!");
                    }
                }
            }
            catch { }
            //перерисовываем listView1
            FillByFiles(currentFolderPath);
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copyPathToClipboard();
            copiedToClipboard = false;
        }
    }
}
