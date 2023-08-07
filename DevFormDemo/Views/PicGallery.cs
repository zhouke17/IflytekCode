using DevExpress.Utils.Drawing;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using System.Drawing;

namespace DevFormDemo
{
    public partial class PicGallery : DevExpress.XtraEditors.XtraUserControl
    {
        public PicGallery()
        {
            InitializeComponent();
            GalleryInit();
            Init();
        }

        public void GalleryInit()
        {

            Image im1 = Image.FromFile(@"C:/Users/kezhou3/Pictures/头像/1.jpeg");
            Image im2 = Image.FromFile(@"C:/Users/kezhou3/Pictures/头像/2.jpeg");
            Image im3 = Image.FromFile(@"C:/Users/kezhou3/Pictures/头像/3.jpeg");
            Image im4 = Image.FromFile(@"C:/Users/kezhou3/Pictures/头像/4.jpeg");
            Image im5 = Image.FromFile(@"C:/Users/kezhou3/Pictures/头像/5.jpeg");
            Image im6 = Image.FromFile(@"C:/Users/kezhou3/Pictures/头像/6.jpeg");

            galleryControl1.Gallery.ItemImageLayout = ImageLayoutMode.ZoomInside;
            galleryControl1.Gallery.ImageSize = new Size(100, 50);
            galleryControl1.Gallery.ShowItemText = false;//隐藏元素名称
            galleryControl1.Gallery.ShowGroupCaption = false;//隐藏分组组名

            GalleryItemGroup group1 = new GalleryItemGroup();
            group1.Caption = "Cars";
            galleryControl1.Gallery.Groups.Add(group1);

            //GalleryItemGroup group2 = new GalleryItemGroup();
            //group2.Caption = "People";
            //galleryControl1.Gallery.Groups.Add(group2);

            group1.Items.Add(new GalleryItem(im1, "BMW", ""));
            group1.Items.Add(new GalleryItem(im2, "Ford", ""));
            group1.Items.Add(new GalleryItem(im3, "Mercedec-Benz", ""));

            group1.Items.Add(new GalleryItem(im4, "Anne Dodsworth", ""));
            group1.Items.Add(new GalleryItem(im5, "Hanna Moos", ""));
            group1.Items.Add(new GalleryItem(im6, "Janet Leverling", ""));

        }
        public void Init()
        {
            galleryControl1.Gallery.ItemRightClick += (s, e) =>
            {
                popupMenu1.ClearLinks();
                var deleteBtn = new BarButtonItem(barManager1, "删除");
                deleteBtn.ItemClick += (x, y) =>
                {
                    foreach (GalleryItemGroup group in galleryControl1.Gallery.Groups)
                    {
                        if (group.Items.Contains(e.Item))
                        {
                            group.Items.Remove(e.Item);
                        }
                    }
                };
                popupMenu1.AddItem(deleteBtn);
                popupMenu1.ShowPopup(MousePosition);
            };
        }
    }
}
