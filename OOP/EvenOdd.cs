namespace OOP
{
    internal class EvenOdd
    {
        static Menu login = new Menu();
        public static void Menu()
        {
            int choice = 0;
            while (choice != 3)
            {
                Console.Clear();
                Console.WriteLine("======================================");
                Console.WriteLine("           MENU GANJIL GENAP          ");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("1. Cek Ganjil/Genap");
                Console.WriteLine("2. Print Ganjil/Genap (dengan limit)");
                Console.WriteLine("3. Logout");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine();
                Console.Write("Pilihan: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        // Meminta pengguna memasukkan bilangan yang ingin dicek
                        Console.Write("Masukkan bilangan yang ingin di cek: ");
                        int input_number = int.Parse(Console.ReadLine());

                        // Memeriksa apakah input valid
                        if (input_number <= 0)
                        {
                            Console.WriteLine("Invalid input");
                            break;
                        }

                        // Memanggil EvenOddCheck untuk mengecek bilangan ganjil/genap dan mencetak hasilnya
                        Console.WriteLine(EvenOddCheck(input_number));
                        break;
                    case 2:

                        // Meminta pengguna memilih ganjil/genap dan memasukkan batas limit
                        Console.Write("Pilih (Ganjil/Genap): ");
                        string input_option = Console.ReadLine();
                        Console.Write("Masukkan limit: ");
                        int input_limit = int.Parse(Console.ReadLine());

                        // Memeriksa apakah limit valid
                        if (input_limit <= 0)
                        {
                            Console.WriteLine("Input limit tidak valid!");
                            break;
                        }

                        // Memeriksa apakah pilihan valid
                        if (input_option != "Ganjil" && input_option != "Genap")
                        {
                            Console.WriteLine("Input pilihan tidak valid!");
                            break;
                        }

                        // Memanggil PrintEvenOdd untuk mencetak bilangan ganjil/genap sesuai dengan pilihan dan limit
                        PrintEvenOdd(input_limit, input_option);
                        Console.WriteLine();
                        break;
                    case 3:
                        // Keluar dari program
                        login.MainMenu();
                        break;
                    default:
                        // Menampilkan pesan jika pilihan tidak valid
                        Console.WriteLine("Input pilihan tidak valid!");
                        break;
                }

                Console.WriteLine("======================================");
                Console.WriteLine();
            }
        }

        // Untuk mengecek apakah bilangan input merupakan bilangan genap atau ganjil
        static string EvenOddCheck(int input)
        {
            return input % 2 == 0 ? "Genap" : "Ganjil";
        }

        static void PrintEvenOdd(int limit, string choice)
        {
            // Jika limit kurang dari atau sama dengan 0, maka keluar dari fungsi
            if (limit <= 0)
            {
                return;
            }

            // Jika pilihan bukan "Ganjil" atau "Genap", maka keluar dari fungsi
            if (choice != "Ganjil" && choice != "Genap")
            {
                return;
            }


            for (int i = 1; i <= limit; i++)
            {
                // Memeriksa apakah bilangan i merupakan bilangan ganjil (i % 2 == 1) dan pilihan adalah "Ganjil",
                // atau bilangan i merupakan bilangan genap (i % 2 == 0) dan pilihan adalah "Genap"
                if ((i % 2 == 1 && choice == "Ganjil") || (i % 2 == 0 && choice == "Genap"))
                {
                    Console.Write(i + ", ");
                }
            }
        }

        public static void Main()
        {
            Menu();
        }
    }
}
