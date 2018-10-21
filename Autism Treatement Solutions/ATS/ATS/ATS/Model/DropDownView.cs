using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;
namespace ATS.Model
{

   class DropDownElement : Label
    {
        public int Index;

        public DropDownElement(int i) : base()
        {
            Index = i;
        }
    }

    public class DropDownList<T> : RelativeLayout
    {

        private Label name;
        private Label selected;
        private List<string> objectNames;
        private List<T> objects;
        private int selectedIndex = 0;

        private Frame dropDownFrame;

        private StackLayout parent;

        public Command OnSelected;

        public DropDownList(StackLayout p, string n, List<string> oNs, List<T> objs)
        {
            parent = p;
            objectNames = oNs;
            objects = objs;

            name = new Label();
            name.Text = n;
            selected = new Label();
            selected.Text = oNs[0];
            selected.BackgroundColor = Color.LightGray;
            selected.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(() => { ToggleDropDown(); }) });

            dropDownFrame = new Frame();
            dropDownFrame.OutlineColor = Color.Black;
            ScrollView dropDown = new ScrollView();
            StackLayout dropDownStack = new StackLayout();
            dropDownStack.BackgroundColor = Color.White;
            int index = 0;
            foreach(string s in objectNames)
            {
                DropDownElement label = new DropDownElement(index);
                label.Text = s;
                label.BackgroundColor = Color.LightGray;
                label.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(() => { Select(label.Index); }) });
                dropDownStack.Children.Add(label);
                index++;
            }
            dropDownFrame.HeightRequest = 0;
            dropDown.Content = dropDownStack;
            dropDownFrame.Content = dropDown;
            dropDownFrame.IsVisible = false;

            Children.Add(name, Constraint.RelativeToParent((parent) => { return 0; }));
            Children.Add(dropDownFrame, Constraint.RelativeToView(name, (lay, parent) => { return parent.Width + 5; }),
                Constraint.RelativeToView(name, (lay, parent) => { return parent.Height + 5; }), Constraint.RelativeToParent((parent) => { return parent.Width; }));
            Children.Add(selected, Constraint.RelativeToView(dropDownFrame, (lay, parent) => { return parent.X; }),
                null, Constraint.RelativeToParent( (parent) => { return parent.Width - 40; }));
        }

        private void ToggleDropDown()
        {
            dropDownFrame.IsVisible = !dropDownFrame.IsVisible;
            if(dropDownFrame.IsVisible)
            {
                HeightRequest = 250;
                dropDownFrame.HeightRequest = 180;
            }
            else
            {
                HeightRequest = 30;
                dropDownFrame.HeightRequest = 0;
            }
        }

        public void Disable()
        {
            IsEnabled = false;
            name.TextColor = Color.Gray;
            selected.TextColor = Color.Gray;
        }

        public void SetSelected(T val)
        {
            int index = objects.IndexOf(val);
            selectedIndex = index;
            selected.Text = objectNames[index];
        }

        public delegate void SelectCallback(T obj);
        private void Select(int i)
        {
            selectedIndex = i;
            selected.Text = objectNames[i];
            //do not remove this if statement, will cause IOS to crash
            if (OnSelected != null)
                OnSelected.Execute(objects[i]);

            ToggleDropDown();
        }

        public T GetSelected()
        {
            return objects[selectedIndex];
        }
    }
}
