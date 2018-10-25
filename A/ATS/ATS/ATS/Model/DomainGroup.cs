using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace ATS.Model
{
    public class DomainGroup : ContentPage
    {
        public static List<string> domainNames = new List<string> {"domain 1", "domain 2"};
        public static List<string> subCatNames = new List<string> { "subCat 1", "subCat 2" };
        public static List<string> goalNames = new List<string> { "goal 1", "goal 2" };
        public static List<string> taskNames = new List<string> { "task 1", "task 2" };
        public static List<List<string>> orderedTestNames = new List<List<string>> { domainNames, subCatNames, goalNames, taskNames };

        //so that we can scroll around on the page
        private ScrollView mainView;

        public NestedStackLayout domainLayout;

        //in case we want the names for these for something
        private Dictionary<NestedStackLayout.NestedTypes, List<NestedStackLayout>> stacks;
        private List<NestedStackLayout> allStacks;
        public DomainGroup() : base()
        {
            stacks = new Dictionary<NestedStackLayout.NestedTypes, List<NestedStackLayout>>();
            allStacks = new List<NestedStackLayout>();
            mainView = new ScrollView();
            Content = mainView;
        }

        public void RegisterStack(NestedStackLayout.NestedTypes type, NestedStackLayout ele)
        {
            if(!stacks.ContainsKey(type))
            {
                stacks[type] = new List<NestedStackLayout>();
            }
            stacks[type].Add(ele);
            allStacks.Add(ele);
        }

        public List<NestedStackLayout> GetStackLayouts(NestedStackLayout.NestedTypes type)
        {
            return stacks[type];
        }

        public List<NestedStackLayout> GetAllStacks()
        {
            return allStacks;
        }

        public void AddButtonPressed(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DomainGroupEditor(this));
        }

        public void EmptyInitialize(string n)
        {
            domainLayout = NestedStackLayout.LoadLayout(this, null, n, NestedStackLayout.NestedTypes.DomainGroup);
            SetStack(domainLayout);
        }

        private void SetStack(NestedStackLayout stack)
        {
            mainView.Content = stack;
        }

        //potential function to load a domain from a data file?
        public static DomainGroup LoadDomains(string patient, string path = "")
        {
            if(path == "")
            {
                //provide a test domain
                DomainGroup result = new DomainGroup();
                NestedStackLayout testStack = NestedStackLayout.LoadLayout(result, null, patient, NestedStackLayout.NestedTypes.DomainGroup);
                BuildTestNestedLayout(result, orderedTestNames, 0, testStack);
                result.domainLayout = testStack;
                result.SetStack(testStack);
                return result;
            }

            //otherwise load stuff
            return null;
        }

        //this will need to be rewritten to use a data file
        private static void BuildTestNestedLayout(DomainGroup dg, List<List<string>> orderedNames, int curIndex, NestedStackLayout parent)
        {
            if (curIndex >= orderedNames.Count)
                return;
                var names = orderedNames[curIndex];
                foreach (string name in names)
                {
                    //this is a really hacky way to set the NestedStackLayout type but this is just a test
                    NestedStackLayout child = NestedStackLayout.LoadLayout(dg, parent, name, (NestedStackLayout.NestedTypes) curIndex + 1);
                    BuildTestNestedLayout(dg, orderedNames, curIndex + 1, child);
                    parent.AddSubView(child);
                }
        }

    }

}
