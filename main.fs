open System
open System.IO
open System.Net
open System.Text

let writeToFile filename buffer =
  use fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write)
  fs.Write(buffer, 0, buffer.Length)

let readFromWeb url =
  use c = new WebClient()
  c.DownloadString(Uri(url))

let GetBytes (s:string) = Encoding.ASCII.GetBytes(s)

[<EntryPoint>]
let main args =
  readFromWeb "http://www.google.com" |> GetBytes |> writeToFile "test.txt"
  (*
  let html = readFromWeb "http://www.google.com"
  let buffer = GetBytes html
  writeToFile "test.txt" buffer
  *)
  0