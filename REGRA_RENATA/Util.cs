using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net.Mail;
using System.Web.UI.WebControls;
using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Globalization;
using System.Configuration;
using DAL_RENATA;
using System.Collections;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using REGRA_RENATA;

namespace REGRA_RENATA
{
    public class Util
    {

        public static bool UploadArquivo(FileUpload file, string caminhoCompleto)
        {
            bool ok = false;

            try
            {
                file.SaveAs(caminhoCompleto);

                ok = true;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao fazer upload. " + e.Message);
            }

            return ok;
        }


        public static bool ExcluirArquivo(string endereco, int? idUsuarioLogado, string ip)
        {
            bool ok = false;

            try
            {
                File.Delete(endereco);

                if (!ArquivoExists(endereco, idUsuarioLogado, ip))
                {
                    ok = true;
                }
                else
                {

                    string mensagem = "Erro ao Deletar o Arquivo [ExcluirArquivo - Utils.cs]";


                    Log log = new Log() { IdUsuario = idUsuarioLogado, Mensagem = mensagem };

                    LogBO logBO = new LogBO();
                    logBO.Salvar(log);
                    ok = false;
                }
            }
            catch (Exception e)
            {
                string mensagem = "Erro ao deletar arquivo. " + e.Message;

                Log log = new Log() { IdUsuario = idUsuarioLogado, Mensagem = mensagem };

                LogBO logBO = new LogBO();
                logBO.Salvar(log);

                ok = false;
            }

            return ok;
        }


        public static bool ArquivoExists(string endereco, int? idUsuarioLogado, string ip)
        {
            bool ok = false;

            try
            {
                if (File.Exists(endereco))
                {
                    ok = true;
                }
                else
                {
                    ok = false;
                }
            }
            catch (Exception e)
            {
                string mensagem = "Erro ao verificar se arquivo existe. " + e.Message;

                Log log = new Log() { IdUsuario = idUsuarioLogado, Mensagem = mensagem };

                LogBO logBO = new LogBO();
                logBO.Salvar(log);

                ok = false;
            }

            return ok;
        }


        public static bool DiretorioExists(string caminho)
        {
            bool ok = false;

            try
            {
                if (Directory.Exists(caminho))
                {
                    ok = true;
                }
                else
                {
                    ok = false;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao Verificar se um Diretório existe. [ " + e.Message + " ]");
            }

            return ok;
        }


        private static void ResizeImage(ref int imageWidth, ref int imageHeight, int maxWidth, int maxHeight)
        {
            double a, b, c;

            if (imageWidth > maxWidth)
            {
                a = System.Convert.ToDouble(maxWidth);
                b = System.Convert.ToDouble(imageWidth);
                c = (double)(a / b);
                imageHeight = (int)(imageHeight * (c));
                imageWidth = maxWidth;
            }
            if (imageHeight > maxHeight)
            {
                float fAUX = (float)((float)maxHeight / (float)imageHeight);
                imageWidth = (int)(imageWidth * fAUX);
                imageHeight = maxHeight;
            }
        }


        public static void UploadImagem(string caminhoAtual, string pastaDestino, string imgNome, int maxWidth, int maxHeight)
        {
            try
            {
                string photoPath = System.IO.Path.Combine(pastaDestino, imgNome + ".jpg");

                System.Drawing.Image imgFoto = System.Drawing.Image.FromFile(caminhoAtual);


                int refImgFotoWidth = imgFoto.Width;
                int refImgFotoHeight = imgFoto.Height;
                ResizeImage(ref refImgFotoWidth, ref refImgFotoHeight, maxWidth, maxHeight);

                System.Drawing.Bitmap ibitmap = new System.Drawing.Bitmap(imgFoto, refImgFotoWidth, refImgFotoHeight);

                System.Drawing.Image newImage = ibitmap;
                System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(newImage);

                FileStream fileStream = new FileStream(photoPath, FileMode.Create);
                newImage.Save(fileStream, System.Drawing.Imaging.ImageFormat.Jpeg);

                g.Dispose();
                imgFoto.Dispose();

                ibitmap.Dispose();
                fileStream.Flush();
                fileStream.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public string PegarIp()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }
            return context.Request.ServerVariables["REMOTE_ADDR"];
        }
    }
}