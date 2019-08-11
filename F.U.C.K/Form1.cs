/*
 written by wisnshaftler 
 wisnshaftler@gmail.com
 https://github.com/wisnshaftler
 
 FOSS community sri lanka
 Release Date :- 2019/8/10

 There are some bugs :) fix and use xD.

 #Hail_Iron_Man we love you 3000
 #Hail_S.H.I.E.L.D
 #Hail_Avengers
 
 #FOSS 
 #FOSSLK 
 
 Thanks Rashan give me this idea!
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace F.U.C.K
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            postmax = Convert.ToInt32(Math.Round(numberBox.Value, 0));
            browser.Hide();
            numberBox.Enabled = false;
            inactiveunfriend = true;
            allunfriend = false;
            deleteallpost = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            browser.Navigate("https://mbasic.facebook.com/profile.php?ref_component=mbasic_home_header");
        }

        public bool newLink = false;

        private void button4_Click(object sender, EventArgs e)
        {
            elakiriFriend.Add(listBox1.GetItemText(listBox1.SelectedItem));
            frinedList.Remove(listBox1.GetItemText(listBox1.SelectedItem));

            listBox1.DataSource = null;
            listBox2.DataSource = null;
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            label2.Text = "Apatha Friends : unfriend list " + frinedList.Count.ToString();
            label3.Text = "Elakiri Friends " + elakiriFriend.Count.ToString();

            listBox1.DataSource = frinedList;
            listBox2.DataSource = elakiriFriend;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frinedList.Add(listBox2.GetItemText(listBox2.SelectedItem));
            elakiriFriend.Remove(listBox2.GetItemText(listBox2.SelectedItem));

            listBox2.DataSource = null;
            listBox1.DataSource = null;

            label2.Text = "Apatha Friends : unfriend list " + frinedList.Count.ToString();
            label3.Text = "Elakiri Friends " + elakiriFriend.Count.ToString();

            listBox1.DataSource = frinedList;
            listBox2.DataSource = elakiriFriend;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            boolUrlcheck = true;
            boolSeeMore = true;
            boolElakiriFriend = true;
            boolgetfriend = true;
            startUnfrined = true;
            
            button4.Enabled = false;
            button5.Enabled = false;
            button8.Enabled = false;

            unfriendCount = frinedList.Count - 1;
            linkhavetounfriend = true;
            browser.Navigate(frinedList[unfriendCount]);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            browser.Hide();
            listBox1.Hide();
            listBox2.Hide();
            browser.Hide();
            numberBox.Enabled = false;
            allunfriend = true;
            deleteallpost = false;
            inactiveunfriend = false;
            button1.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            boolgetfriend = false;
            startUnfrined = false;
            browser.Navigate("https://mbasic.facebook.com/profile.php?ref_component=mbasic_home_header");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            allunfriend = false;
            inactiveunfriend = false;

            button1.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            browser.Navigate("https://mbasic.facebook.com/profile.php?ref_component=mbasic_home_header");
        }

        
        private void button3_Click_1(object sender, EventArgs e)
        {
            Process.Start(listBox1.GetItemText(listBox1.SelectedItem));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Process.Start(listBox2.GetItemText(listBox2.SelectedItem));
        }

        private void button8_Click(object sender, EventArgs e)
        {
            browser.Hide();
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;

            deleteallmsg = true;
            allunfriend = false;
            inactiveunfriend = false;
            browser.Navigate("mbasic.facebook.com/messages/");
        }
        public void deleteallmessages()
        {
            if (!browser.Document.Body.InnerHtml.Contains("messages/read/?"))
            {
                label1.Text = "All chats deleted. Deleted chats :- " + msgloopcount.ToString();
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                deleteallmsg = false;
                return;
            }

            label1.Text = msgloopcount.ToString() + " chats deleted";
            button8.Enabled = false;
            
            if (linkhavetodelete == false && confirmdelete == false)
            {
                foreach (HtmlElement eli in browser.Document.Links)
                {
                    String link = eli.GetAttribute("href").ToString();
                    if (link.Contains("messages/read/"))
                    {
                        
                        linkhavetodelete = true;
                        eli.InvokeMember("click");
                    }
                }
            }
            if(linkhavetodelete == true && confirmdelete == false)
            {
               
                foreach (HtmlElement eli in browser.Document.GetElementsByTagName("input"))
                {
                    if (eli.GetAttribute("name").ToString() ==("delete"))
                    {
                        
                        confirmdelete = true;
                        eli.InvokeMember("click");
                    }
                }
            }
            if (linkhavetodelete == true && confirmdelete == true)
            {
                foreach (HtmlElement eli in browser.Document.Links)
                {
                    String link = eli.GetAttribute("href").ToString();
                    if (link.Contains("/messages/action"))
                    {
                        
                        linkhavetodelete = false;
                        confirmdelete = false;
                        msgloopcount += 1;
                        eli.InvokeMember("click");
                    }
                }
            }
        }
        //declare variables
        public bool inactiveunfriend, allunfriend, deleteallpost, wb2fullstory, wb2delete, wb2checkUrl, clickMore, linkhavetounfriend, confirmunfriend, startUnfrined, boolUrlcheck, boolSeeMore, boolElakiriFriend, boolFrinedList, boolUnfriend, boolgetfriend = false;
        public bool linkhavenow,linkhavetodelete, confirmdelete, deleteallmsg = false;
        public bool redirectToHome, redirectToFriend = false;

        public int elakiriCounter, unfriendCount, refreshCounter, postmax, msgloopcount = 0;
        public List<String> postLink = new List<String>();
        public List<String> elakiriFriend = new List<String>();
        public List<String> frinedList = new List<String>();
        public List<String> removeList = new List<String>();
        //end declare variables

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        private void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
            if (boolUrlcheck == false)
            {
                checkUrl(boolUrlcheck);
            }
            if (inactiveunfriend == true)
            {
                
                if (boolSeeMore == false)
                {
                    getPostLink(boolSeeMore);
                }
                else if (boolElakiriFriend == false)
                {
                    getElakiriFriendList(boolElakiriFriend, elakiriCounter);
                }
                else if (boolgetfriend == false)
                {
                    getfrinedlist();
                }
                else if (startUnfrined == true)
                {
                    startunfrined();
                }
            }if( allunfriend == true)
            {
                button2.Enabled = false;
                if (boolgetfriend == false)
                {
                    getfrinedlist();
                }
                else if (startUnfrined == false)
                {
                    startunfrined();
                }
            }if(deleteallmsg == true)
            {
                deleteallmessages();
               
            }
        }
        //check url and redirect to profile page
        public void checkUrl(bool check)
        {
            postmax = Convert.ToInt32(Math.Round(numberBox.Value, 0));//post gana gatta

            if (browser.Document.Body.InnerText.Contains("Profile"))
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button8.Enabled = true;
               
                label1.Text = "redirecting";
                label1.Text = "Click inactive unfriend, All unfriend or Delete all Messages";
                boolUrlcheck = true;
                
                browser.Navigate("https://mbasic.facebook.com/profile.php?ref_component=mbasic_home_header");
            }
            if (browser.Url.ToString().Contains("https://mbasic.facebook.com/?_rdr") || browser.Url.ToString() == "https://mbasic.facebook.com")
            {
                
                label1.Text = "redirecting";
                label1.Text = "Click inactive unfriend, All unfriend or Delete all Messages";
                boolUrlcheck = true;
                browser.Navigate("https://mbasic.facebook.com/profile.php?ref_component=mbasic_home_header");
            }
            else
            {
                //label1.Text="redda els eka diwwa";
            }
        }
        //end of profile page redirection

        void getPostLink(bool seeMore)
        {
            button1.Enabled = false;
            numberBox.Enabled = false;
            if (seeMore == false)
            {
                label1.Text = "Getting posts " + postLink.Count.ToString() + " done";
                foreach (HtmlElement eli in browser.Document.Links)
                {
                    String linkItem = eli.GetAttribute("HREF").ToString();//geting page all links
                    if (linkItem.Contains("/story.php?story_fbid=") && eli.InnerText == "Full Story")//check links contain full story
                    {
                        postLink.Add(linkItem);//add to post link 
                    }
                }
                if (browser.DocumentText.ToString().Contains("/profile/timeline/stream/?cursor=") && postLink.Count < postmax)
                {
                    //check see more and click if not call to get friend function
                    foreach (HtmlElement eli in browser.Document.Links)
                    {
                        if (eli.GetAttribute("href").Contains("/profile/timeline/stream/?cursor="))
                        {
                            //if have see more and click it
                            eli.InvokeMember("click");
                        }
                    }
                }
                else
                {
                    boolSeeMore = true;
                    elakiriCounter = postLink.Count - 1;
                    getElakiriFriendList(boolElakiriFriend, elakiriCounter);
                }
            }
        }
        //end of get post link

        //get Elakiri Friend list
        public void getElakiriFriendList(bool check, int counter)
        {
            label1.Text = "Getting Active Friends. " + elakiriFriend.Count.ToString() + " found. Scanend "+(postLink.Count - counter).ToString()+" posts from "+postLink.Count.ToString()+" posts";
            if (counter > 0)
            {
                if (newLink == false && linkhavenow == false)
                {
                    linkhavenow = true;
                    browser.Navigate(postLink[counter]);
                }
                else if (newLink == false && linkhavenow == true)// browser eke post ekak load welanam
                {
                    foreach (HtmlElement eli in browser.Document.Links)
                    {//thiyena okkoma links gannawa
                        if (eli.GetAttribute("href").Contains("ufi/reaction/profile/browser/"))
                        {//aragena oya contains kiyana eka athule thiyena eka thiyeda balala eka uda click koranawa
                            newLink = true;
                            linkhavenow = false;
                            eli.InvokeMember("click");
                        }
                    }

                }
                else if (newLink == true && linkhavenow == false)
                {
                    //thiyena okkoma links gannawa
                    foreach (HtmlElement eli in browser.Document.Links)
                    {
                        //contain eke thiyena okkoma gannawa
                        if (eli.GetAttribute("href").Contains("ufi/reaction/profile/browser/fetch/") )
                        {
                            if (eli.InnerText.Contains("All 0"))//ekek wat like korala nattan passata goin
                            {
                                newLink = false;
                                if (elakiriCounter != 0)
                                {
                                    elakiriCounter -= 1;
                                    browser.Navigate(postLink[elakiriCounter]);
                                }
                            }
                            else
                            {//mokek hari like koralanam aye list eka load karanwa limit eka bara ganakata set korala 
                                String golink = eli.GetAttribute("href").ToString().Replace("limit=10", "limit=99999");
                                newLink = true;
                                linkhavenow = true;
                                browser.Navigate(golink);//ehema load kornawa
                            }
                        }

                    }
                }
                else if (newLink == true && linkhavenow == true)
                {
                    foreach (HtmlElement eli in browser.Document.Links)//okkoma link gannawa
                    {
                        var links = eli.GetAttribute("href").ToString();//get all links in page
                        if (!links.Contains("https://mbasic.facebook.com/ufi/reaction/") &&
                            !links.Contains("https://mbasic.facebook.com/story.php") &&
                            !links.Contains("https://mbasic.facebook.com/a/mobile/friends/add_friend.php?") &&
                            !links.Contains("https://mbasic.facebook.com/home.php") &&
                            links != ("https://mbasic.facebook.com/profile.php")
                            )
                        {
                            if (!elakiriFriend.Contains(links))
                            {
                                elakiriFriend.Add(links);//badu link list eke nattan add koranwa
                            }
                        }
                    }
                    newLink = false;
                    linkhavenow = false;
                    if (elakiriCounter != 0)//mekath thopita kiyanda onenam programming nokara palayan tahuduwenda :/
                    {
                        elakiriCounter -= 1;
                        browser.Navigate(postLink[elakiriCounter]);//browser eke link ekak load koranwa
                    }
                    else if (elakiriCounter >= 0)
                    {
                        boolElakiriFriend = true;
                        getfrinedlist();//onna oya function eka hari method eka hari void eka hari mona labbata hari call koranwa
                    }
                }

            }
            else //else counter >0
            {
                getfrinedlist();
            }

        }
        //end get liked friend list
        public void getfrinedlist()
        {
            bool see1 = true;//meka mona magulakata dammada kiyala mathaka na 
            label1.Text = "Getting friend list " + frinedList.Count.ToString() + " friends found";
            if (redirectToHome == false && redirectToFriend == false)
            {
                redirectToHome = true;
                browser.Navigate("https://mbasic.facebook.com/profile.php?ref_component=mbasic_home_header");//me link ekata yanawa
            }
            
            else if (redirectToFriend == false && redirectToHome == true)
            {
                foreach (HtmlElement eli in browser.Document.Links)//okkoma link gannawa
                {
                    var link = eli.GetAttribute("href").ToString();
                    if ((link.Contains("friends?lst=") || link.Contains("friends&lst")) && eli.InnerText == "Friends")//oya dila thiyena ewa thiyena link eka gannawa
                    {
                        redirectToFriend = true;
                        eli.InvokeMember("click");//aragena eke uda obanawa
                    }
                    
                }
            }
            else if (redirectToFriend == true && redirectToHome == true)
            {
                foreach (HtmlElement eli in browser.Document.Links)//okkoma link gannawa
                {
                    var link = eli.GetAttribute("href").ToString();
                    if (!link.Contains("https://mbasic.facebook.com/ufi/reaction/") &&
                        !link.Contains("https://mbasic.facebook.com/story.php") &&
                        !link.Contains("https://mbasic.facebook.com/a/mobile/friends/add_friend.php?") &&
                        !link.Contains("https://mbasic.facebook.com/messages") &&
                        !link.Contains("https://mbasic.facebook.com/profile.php?lst=") &&
                        !link.Contains("https://mbasic.facebook.com/notifications.php") &&
                        !link.Contains("https://mbasic.facebook.com/buddylist.php") &&
                        !link.Contains("https://mbasic.facebook.com/friends/") &&
                        !link.Contains("https://mbasic.facebook.com/pages") &&
                        !link.Contains("https://mbasic.facebook.com/groups/?") &&
                        !link.Contains("https://mbasic.facebook.com/events") &&
                        !link.Contains("https://mbasic.facebook.com/notes") &&
                        !link.Contains("https://mbasic.facebook.com/saved") &&
                        !link.Contains("https://mbasic.facebook.com/settings") &&
                        !link.Contains("https://mbasic.facebook.com/help") &&
                        !link.Contains("https://mbasic.facebook.com/menu") &&
                        !link.Contains("https://mbasic.facebook.com/photo.php?") &&
                        !link.Contains("https://mbasic.facebook.com/findfriends/") &&
                        !link.Contains("allactivity?") &&
                        !link.Contains("https://mbasic.facebook.com/privacyx") &&
                        !link.Contains("https://mbasic.facebook.com/profile.php?v") &&
                        !link.Contains("https://mbasic.facebook.com/bugnub") &&
                        !link.Contains("https://mbasic.facebook.com/policies/") &&
                        !link.Contains("https://mbasic.facebook.com/logout.php") &&
                        !link.Contains("friends?unit_cursor=") &&
                        !link.Contains("v=timeline&lst=") &&
                        !link.Contains("lst=") &&
                        !link.Contains("about?") &&
                        !link.Contains("photos?") &&
                        !link.Contains("v=likes") &&
                        !link.Contains("about?") &&
                        !link.Contains("allactivity") &&
                        !link.Contains("https://mbasic.facebook.com/home.php") ||
                        link.Contains("mbasic.facebook.com/friends/hovercard"))
                    {//oya uda thiyen labbawal nattan hari yama magula thiyenawanam hari gannawa
                        if (!frinedList.Contains(link))
                        {
                            frinedList.Add(link);//aragena balala nattan obanwa
                            link = "";
                         }
                        else
                        {
                            link = "";
                        }
                    }
                }
                
                foreach (HtmlElement eli in browser.Document.Links)//okkoma link gannawa
                {
                    var links = eli.GetAttribute("href").ToString();
                    if ((links.Contains("friends?unit_cursor=") || links.Contains("friends&unit_cursor=")) && (eli.InnerText.Contains("See More Friends") || eli.InnerText.Contains("See More friends") || eli.InnerText.Contains("See more friends") || eli.InnerText.Contains("see more friends")))//oya dila thiyena ewa thiyena link eka gannawa
                    {//
                        see1 = true;
                        eli.InvokeMember("click");//obanawa
                    }
                }
                
            }

            if(browser.Url.ToString().Contains("unit_cursor=")&& !browser.Document.Body.InnerText.Contains("See more friends")&& !browser.Document.Body.InnerText.Contains("See More Friends"))
            {
                label1.Text = frinedList.Count.ToString() + "friends found";
                boolgetfriend = true;

                if (allunfriend == false)
                {
                    compareFriends();//call kala
                }
                else
                {
                    linkhavetounfriend = true;
                    unfriendCount = frinedList.Count - 1;
                    label1.Text = frinedList[unfriendCount];
                    browser.Navigate(frinedList[unfriendCount]);//automa call wenna liwa 
                }
            }
            
        }

        public void compareFriends()//me redda wadakaranawada kiyala sure ekak na 
        {
            label1.Text = "Comparing friends please wait";
            int counter = elakiriFriend.Count - 1;
            removeList = elakiriFriend;
            
            
            for (int i = 0; i < frinedList.Count; i++)
            {
                if (elakiriFriend.Contains(frinedList[i]))
                {
                    frinedList.Remove(frinedList[i]);
                    Timer timer = new Timer();
                    timer.Interval = 10;
                    timer.Start();
                }
                
                if (frinedList[i] == "https://mbasic.facebook.com/profile.php")
                {
                    frinedList.Remove(frinedList[i]);
                }
            }
            
            listBox1.DataSource = frinedList;
            listBox2.DataSource = elakiriFriend;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            label2.Text = "Apatha Friends : unfriend list " + frinedList.Count.ToString();
            label3.Text = "Elakiri Friends "+ elakiriFriend.Count.ToString();
            label1.Text = "Ready to unfriend. Click left side list item and click remove from unfriend list for keep friends \r\n " +
               "click right side list item and click add to unfriend list for add friend to unfriend list";

        }
        public void startunfrined()//anprens koranna start kora
        {
            button6.Enabled = false;
            if (clickMore == false && confirmunfriend == false && linkhavetounfriend == true)
            {
               
                label1.Text = "Removing :- " + browser.Url.ToString() +" " +unfriendCount.ToString()+" friends left";

                if (!browser.Document.Body.InnerText.Contains("Edit Profile Picture") && !browser.Document.Body.InnerText.Contains("Add Friend"))
                {//oya dila thiyena ewa nattan pahala ewa duwanawa
                    foreach (HtmlElement eli in browser.Document.Links)
                    {
                        if (eli.GetAttribute("href").Contains("mbasic/more/?") )//therum ganin hama ekama kotanna kammali
                        {
                            clickMore = true;
                            confirmunfriend = false;
                            eli.InvokeMember("click");
                        }
                        else if (eli.GetAttribute("href").Contains("https://mbasic.facebook.com/removefriend.php?friend_id"))
                        {
                            clickMore = false;
                            confirmunfriend = true;
                            linkhavetounfriend = true;
                            eli.InvokeMember("click");
                        }

                    }
                }
                else
                {
                    
                    //label1.Text = "gatte na"+unfriendCount.ToString();
                    if (unfriendCount != 0)
                     {
                        unfriendCount -= 1;
                        browser.Navigate(frinedList[unfriendCount]);
                     }
                }
             }
            else if (clickMore == true && confirmunfriend == false && linkhavetounfriend == true)
            {
                foreach (HtmlElement eli in browser.Document.Links)
                {
                    if (eli.GetAttribute("href").Contains("https://mbasic.facebook.com/removefriend.php?friend_id"))
                    {
                        confirmunfriend = true;
                        clickMore = false;
                        eli.InvokeMember("click");
                    }
                }
            }
            else if (clickMore == false && confirmunfriend == true && linkhavetounfriend == true)
            {
                if (refreshCounter >= 10)
                {
                    refreshCounter = 0;
                    browser.Navigate(browser.Url.ToString());
                }
                else
                {
                    refreshCounter++;
                }

                foreach (HtmlElement eli in browser.Document.GetElementsByTagName("input"))//input tags okkoma gannawa
                {
                    if (eli.GetAttribute("name").ToString().Contains("confirm"))//aragena eke nama confirm thiyena ewa aran obanawa
                    {  
                        linkhavetounfriend = false;
                        eli.InvokeMember("click");
                    }
                }
            }
            else if (linkhavetounfriend == false && clickMore == false && confirmunfriend == true)
            {
                if (unfriendCount != 0)
                {
                    linkhavetounfriend = true;
                    confirmunfriend = false;
                    clickMore = false;
                    unfriendCount -= 1;
                    browser.Navigate(frinedList[unfriendCount]);//yanawa aluth link ekakata
                }
                else
                {
                    label1.Text = "Job Done! please log out";//wade pinis
                    browser.Visible = true;
                    allunfriend = inactiveunfriend = deleteallpost = false;
                    button1.Enabled = true;
                    button2.Enabled = true;
                   

                    //browser.Navigate("javascript:void((function(){var a,b,c,e,f;f=0;a=document.cookie.split('; ');for(e=0;e<a.length&&a[e];e++){f++;for(b='.'+location.host;b;b=b.replace(/^(?:%5C.|[^%5C.]+)/,'')){for(c=location.pathname;c;c=c.replace(/.$/,'')){document.cookie=(a[e]+'; domain='+b+'; path='+c+'; expires='+new Date((new Date()).getTime()-1e11).toGMTString());}}}})())");
                }
            }
        }
    }
}
