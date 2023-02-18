# Operation-Systems-2-Project
Project I made for the course "Operation Systems 2" at Faculty of Organization and Informatics. I used .NET and WinForms to implement the solution.

The task was to mplement a program that enables:

* Creation and storage of cryptographic keys in the files secret_key.txt, public_key.txt, and private_key.txt
* Encryption and decryption of the selected file using symmetric and asymmetric algorithms
* Calculation of the message digest (hash) of the input file
* Digital signing of the input file and verification of the digital signature

Instructions: 
Use freely available source code for symmetric and asymmetric encryption and message digest calculation. Each step must be saved in a separate file, 
e.g., encrypted text should be saved in a separate file, digital signature in a separate file, and message digest in a separate file. When decrypting the text, 
it is necessary to load the encrypted text from the file. When verifying the digital signature, it is necessary to reload the digital signature from the file and 
the original file that was signed. It is expected that the correctness of the digital signature will be verified, with possible errors (changes in content) in the 
original file or the file containing the digital signature. The use of insecure algorithms such as DES and MD5 is prohibited.
