using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_126
{
    class Node
    {
        public int Nim;
        public string nama;
        public int kelas;
        public Node next;
    }
    class List
    {
        Node START;
        public List()
        {
            START = null;
        }
        public void input()
        {
            int nim;
            string nm;
            int kls;
            Console.Write("\nEnter the NIM of the student : ");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter the name of the student : ");
            nm = Console.ReadLine();
            Console.Write("\nEnter the Class of the student : ");
            kls = Convert.ToInt32(Console.ReadLine());
            Node newnode = new Node();
            newnode.Nim = nim;
            newnode.nama = nm;
            newnode.kelas = kls;

            if (START == null || kls <= START.kelas)
            {
                if ((START != null) && (kls == START.kelas))
                {
                    Console.WriteLine();
                    return;
                }
                newnode.next = START;
                START = newnode;
                return;
            }
            Node previous, current;
            previous = START;
            current = START;

            while ((current != null) && (kls >= current.kelas))
            {
                if (kls == current.kelas)
                {
                    Console.WriteLine();
                    return;
                }
                previous.next = current;
                previous.next = newnode;
            }
            newnode.next = current;
            previous.next = newnode;
        }
        public bool Search(int kls, ref Node previous, ref Node current)
        {
            previous = START;
            current = START;
            while ((current != null) && (kls != current.kelas))
            {
                previous = current;
                current = current.next;
            }
            if (current == null)
                return false;
            else
                return true;
        }
        public void Traverse()
        {
            if (listEmpty())
                Console.WriteLine("\n The records in the list are: ");
            else
            {
                Console.WriteLine("\nThe records in the list are: ");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.WriteLine("Kelas : " + currentNode.kelas + " " + currentNode.Nim + ". " + currentNode.nama + "\n");
                Console.WriteLine();
            }
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List obj = new List();
            while(true)
            {
                try
                {
                    Console.WriteLine("\n MENU");
                    Console.WriteLine("1. Add a record to the list");
                    Console.WriteLine("2. View all the record from the list");
                    Console.WriteLine("3. search for record in the list");
                    Console.WriteLine("4. EXIT ");
                    Console.WriteLine("\n Enter your choice (1-4) ");
                    char ch = Convert.ToChar(Console.ReadLine());

                    switch (ch)
                    {
                        case '1':
                            {
                                obj.input();
                            }
                            break;
                        case '2':
                            {
                                obj.Traverse();
                            }
                            break ;
                        case '3':
                            {
                                if(obj.listEmpty() == true )
                                {
                                    Console.WriteLine("\n List is empty");
                                    break;
                                }
                                Node previous, current;
                                previous = current = null;
                                Console.WriteLine("\n Enter the Class of the" + "student whole record is to be searched: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref previous, ref current) == false)
                                    Console.WriteLine("\nRecord Not Found");
                                else
                                {
                                    Console.WriteLine("\n Record Found");
                                    Console.WriteLine("\n Class : " + current.kelas);
                                    Console.WriteLine("\n Name : " + current.nama);
                                    Console.WriteLine("\n NIM : " + current.Nim);
                                }
                            }
                            break;
                        case '4':
                            {
                                return;
                            }
                            default:
                            {
                                Console.WriteLine("\n Invalid Option");
                                break;
                            }

                    }
                }
                catch (Exception)
                {
                    Console.Write("");
                }
            }
        }
    }
}

// Jawaban 
// 2. Algoritma yang digunakan adalah Singly Linked List yang didalamnya berisikan algoritma untuk menampilkan(method Traverse),
// menurutkan(method input sekalian data yang masuk di urutkan),
// dan mencari data (method search)

//3. Top dalam argoritma stack berfungsi agar data dapat diisi dan dapat di hapus maka hatrus memiliki TOP,
// TOP juga merupakan nilai awal dari algoritma stack yang menentukan apakah dalam data itu sudah ada isinya atau masih kosong.

// 4. Rear , Front

//5. a. 5 
// b. cara membaca data struktur pohon diatas dengan metode Inorder
// 1) Membaca dimulai dari bagian kiri subtree
// 2) Mendatangi root(parent)
// 3) lalu lanjut bagian kanan subtree 
// sehingga pada gambar diatas jika menggunkan metode Inorder maka hasilnya;
// 15, 20, 25, 31, 32, 35, 30, 48, 50, 66, 69, 67, 65, 70, 90, 94, 98, 99 
