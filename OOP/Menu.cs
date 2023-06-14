namespace OOP
{
    internal class Menu
    {
        Method method = new Method();
        static EvenOdd EvenOdd = new EvenOdd();
        List<User> listUsers = new List<User>();

        public void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("====================");
            Console.WriteLine("  Account Database  ");
            Console.WriteLine("====================");
            Console.WriteLine("1. Login Admin");
            Console.WriteLine("2. Login User");
            Console.WriteLine("3. Exit");
            Console.WriteLine("====================");
            Console.Write("Pilih Menu : ");
            try
            {
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        LoginAdmin();
                        break;
                    case 2:
                        LoginUser(listUsers);
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Input Tidak Valid");
                        Console.ReadKey();
                        this.MainMenu();
                        break;
                }
            }
            catch (Exception) // variabel ex untuk catch
            {
                Console.WriteLine("Maaf Pilihan Menu Tidak Valid");
                Console.ReadKey();
                this.MainMenu();
            }
        }
        public void LoginAdmin()
        {
            Console.Clear();
            Console.WriteLine("===Login Admin===");
            Console.Write("User Name : ");
            string username = Console.ReadLine();
            Console.Write("Password : ");
            string password = Console.ReadLine();
            if (username == "admin" && password == "admin123")
            {
                Initialize();
            }
            else
            {
                Console.WriteLine("Anda bukan admin");
                Console.ReadKey();
                this.MainMenu();
            }
        }
        public void LoginUser(List<User> listUser)
        {
            Console.Clear();
            Console.WriteLine("===Login User===");
            Console.Write("User Name : ");
            string username = Console.ReadLine();
            Console.Write("Password : ");
            string password = Console.ReadLine();
            foreach (User usr in listUser)
            {
                if (usr.Username == username && usr.Password == password)
                {
                    EvenOdd.Menu();
                }
                else
                {
                    Console.WriteLine("Akun tidak ditemukan, Username atau password salah");
                    Console.ReadKey();
                    this.MainMenu();
                }
            }
            if (listUser.Count == 0)
            {
                Console.WriteLine("Data User tidak ada, silahkan hubungi Admin");
                Console.ReadKey();
                MainMenu();
            }
        }

        public void Initialize()
        {
            Console.Clear();
            Console.WriteLine("====Basic Authentication====");
            Console.WriteLine("1. Create User");
            Console.WriteLine("2. Show User");
            Console.WriteLine("3. Search User");
            Console.WriteLine("4. Login User");
            Console.WriteLine("5. Logout");
            Console.Write("Input : ");
            int usrPick = Convert.ToInt32(Console.ReadLine());

            try
            {
                switch (usrPick)
                {
                    case 1:
                        CreateUser(listUsers);
                        break;
                    case 2:
                        ShowUser(listUsers);
                        break;
                    case 3:
                        SearchUser(listUsers);
                        break;
                    case 4:
                        LoginUser(listUsers);
                        break;
                    case 5:
                        MainMenu();
                        //System.Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Error : Input not valid");
                        break;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex);
                Initialize();
            }
        }

        void CreateUser(List<User> listUser)
        {
            Console.Clear();
            Console.Write("First Name : ");
            string firstName = method.ValidationUsername(Console.ReadLine());
            Console.Write("Last Name : ");
            string lastName = method.ValidationUsername(Console.ReadLine());
            Console.Write("Password : ");
            string password = method.ValidationPassword(Console.ReadLine());
            User usr = new User()
            {
                FirstName = firstName,
                LastName = lastName,
                Password = password,
                Username = firstName.Substring(0, 2) + lastName.Substring(0, 2)
            };
            Console.WriteLine(method.Create(listUser, usr));
            Console.ReadKey();
            Initialize();
        }

        void ShowUser(List<User> listUser)
        {
            Console.Clear();
            Console.WriteLine("===== Show User =====");
            method.GetAllUser(listUser);
            Console.WriteLine("\nMenu");
            Console.WriteLine("1. Edit User");
            Console.WriteLine("2. Delete User");
            Console.WriteLine("3. Back");
            Console.Write("Input : ");
            int usrPick = Convert.ToInt32(Console.ReadLine());

            try
            {
                switch (usrPick)
                {
                    case 1:
                        if (listUser.Count <= 0)
                        {
                            Console.WriteLine("Data User Empty");
                            Console.ReadKey();
                            Initialize();
                            break;
                        }
                        else
                        {
                            EditUser(listUser);
                            return;
                        }
                    case 2:
                        DeleteUser(listUser);
                        return;
                    case 3:
                        Initialize();
                        return;
                    default:
                        Console.WriteLine("Error : Input not valid");
                        Console.ReadKey();
                        ShowUser(listUser);
                        return;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex);
                Initialize();
            }
        }

        void EditUser(List<User> listUser)
        {
            Console.Write("ID you want to change : ");
            int id = Convert.ToInt32(Console.ReadLine());

            if (id <= listUser.Count)
            {
                User user = listUser[id - 1];

                Console.Write("First Name : ");
                string firstName = Console.ReadLine();
                if (!string.IsNullOrEmpty(firstName))
                {
                    firstName = method.ValidationUsername(firstName);
                    user.FirstName = firstName;
                }

                Console.Write("Last Name : ");
                string lastName = Console.ReadLine();
                if (lastName != "")
                {
                    lastName = method.ValidationUsername(lastName);
                    user.LastName = lastName;
                }

                Console.Write("Password : ");
                string password = Console.ReadLine();
                if (password != "")
                {
                    password = method.ValidationPassword(password);
                    user.Password = password;
                }

                Console.WriteLine(method.Edit(listUser, user, id));
                Console.ReadKey();
                ShowUser(listUser);
            }
            else
            {
                Console.WriteLine("User Not Found");
                Console.ReadKey();
                ShowUser(listUser);
            }



        }

        void DeleteUser(List<User> listUser)
        {
            try
            {
                Console.Write("ID you want to change : ");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(method.Delete(listUser, id));
                Console.ReadKey();
                ShowUser(listUser);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to delet data");
                ShowUser(listUser);
            }
        }

        void SearchUser(List<User> listUser)
        {
            Console.Clear();
            Console.WriteLine("===== Search Account =====");
            Console.Write("input Name : ");
            string name = Console.ReadLine();
            List<User> search = new List<User>();

            foreach (var user in listUser)
            {
                if (user.FirstName.ToLower() == name.ToLower() || user.LastName.ToLower() == name.ToLower())
                {
                    search.Add(user);
                }
            }
            method.GetAllUser(search);
            Console.ReadKey();
            Initialize();
        }

        /*void LoginUser(List<User> listUser)
        {
            Console.Clear();
            Console.WriteLine("===== Login =====");
            Console.Write("Username : ");
            string username = Console.ReadLine();
            Console.Write("Password : ");
            string password = Console.ReadLine();
            bool userExist = false;
            foreach (var user in listUser)
            {
                if (user.Username == username && user.Password == password)
                {
                    userExist = true;
                    break;
                }
            }
            if (userExist)
            {
                Console.WriteLine("Message : Login Successful");
                Console.ReadKey();
                Initialize();
                return;
            }
            else
            {
                Console.WriteLine("Message : Username or Password not found");
                Console.ReadKey();
                Initialize();
            }
        }*/
    }
}
