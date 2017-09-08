using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net.Mail;
using System.Web.UI.WebControls;
using System.Net;

namespace REGRA_RENATA
{
    public class Util
    {
        /// <summary>
        /// Realiza o Upload de um Arquivo no Servidor.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="caminhoCompleto"></param>
        /// <returns></returns>
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
                throw new Exception("Erro ao Copiar o Arquivo. [ " + e.Message + " ]");
            }

            return ok;
        }

        /// <summary>
        /// Exclui um Arquivo do Servidor.
        /// </summary>
        /// <param name="endereco"></param>
        /// <returns></returns>
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
#pragma warning disable CS0219 // The variable 'mensagem' is assigned but its value is never used
                    string mensagem = "Erro ao Deletar o Arquivo [ExcluirArquivo - Utils.cs]";
#pragma warning restore CS0219 // The variable 'mensagem' is assigned but its value is never used
                    /*
                    Log log = new Log() { Categoria = (int)CategoriaLog.Erro, CodEvento = 30118, IdUsuario = idUsuarioLogado, Ip = ip, Mensagem = mensagem };

                    LogBO logBO = new LogBO();
                    logBO.Salvar(log);
                    ok = false;*/
                }
            }
            catch (Exception e)
            {
                string mensagem = "Erro ao Deletar o Arquivo [ExcluirArquivo - Utils.cs] [ " + e.Message + " - " + e.Source + " ]";
                /*
                Log log = new Log() { Categoria = (int)CategoriaLog.Erro, CodEvento = 30018, IdUsuario = idUsuarioLogado, Ip = ip, Mensagem = mensagem };

                LogBO logBO = new LogBO();
                logBO.Salvar(log);*/

                ok = false;
            }

            return ok;
        }

        /// <summary>
        /// Verifica se um Arquivo existe.
        /// </summary>
        /// <param name="endereco"></param>
        /// <returns></returns>
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
                string mensagem = "Erro ao Verificar a existência de um Endereço [ArquivoExists - Utils.cs] [ " + e.Message + " - " + e.Source + " ]";
                /*
                Log log = new Log() { Categoria = (int)CategoriaLog.Erro, CodEvento = 30019, IdUsuario = idUsuarioLogado, Ip = ip, Mensagem = mensagem };

                LogBO logBO = new LogBO();
                logBO.Salvar(log);
                */
                ok = false;
            }

            return ok;
        }

        /// <summary>
        /// Verifica se um Diretório existe no Servidor.
        /// </summary>
        /// <param name="caminho"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Cria um Novo Diretório no Servidor.
        /// </summary>
        /// <param name="caminho"></param>
        /// <returns></returns>
        public static bool CriarDiretorio(string caminho)
        {
            bool ok = false;

            try
            {
                if (!DiretorioExists(caminho))
                {
                    DirectoryInfo dirInfo = Directory.CreateDirectory(caminho);

                    if (dirInfo.Exists)
                    {
                        ok = true;
                    }
                    else
                    {
                        ok = false;
                    }
                }
                else
                {
                    ok = false;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao Criar um Diretório. [ " + e.Message + " ]");
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

        /// <summary>
        /// Envia um email
        /// </summary>
        /// <param name="nomeRemetente">Nome do Remetente</param>
        /// <param name="emailRemetente">Email do Remetente</param>
        /// <param name="emailDestinatario">Email do Destinatário</param>
        /// <param name="titulo">Título do Email</param>
        /// <param name="isHtml">Se te html na mensagem</param>
        /// <param name="mensagem">Mensagem</param>
        /// <returns>true se foi enviado, e false se não foi</returns>
        public static bool EnviarEmail(string nomeRemetente, string emailRemetente, string emailDestinatario, string titulo, bool isHtml, string mensagem, bool isS4WRemetente)
        {
            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();

            try
            {
                MailAddress remetente = new MailAddress(emailRemetente, nomeRemetente);
                MailAddress mailFrom;

                if (isS4WRemetente)
                {
                    mailFrom = new MailAddress(emailRemetente, nomeRemetente);
                }
                else
                {
                    mailFrom = new MailAddress("contato@s4w.com.br", "S4W Marketing Digital");
                }


                NetworkCredential credenciais = new NetworkCredential("smtp@s4w.com.br", "smtp1510");

                smtpClient.EnableSsl = true;

                smtpClient.Credentials = credenciais;

                //Nome o ip do servidor
                smtpClient.Host = "smtp.gmail.com";

                //Porta (padrão 25)
                smtpClient.Port = 587;

                //Dados do remetente
                message.From = mailFrom;

#pragma warning disable CS0618 // 'MailMessage.ReplyTo' is obsolete: 'ReplyTo is obsoleted for this type.  Please use ReplyToList instead which can accept multiple addresses. http://go.microsoft.com/fwlink/?linkid=14202'
                message.ReplyTo = remetente;
#pragma warning restore CS0618 // 'MailMessage.ReplyTo' is obsolete: 'ReplyTo is obsoleted for this type.  Please use ReplyToList instead which can accept multiple addresses. http://go.microsoft.com/fwlink/?linkid=14202'

                // Endereço do destinatário
                message.To.Add(emailDestinatario);

                //Título do email
                message.Subject = titulo;

                message.Priority = MailPriority.Normal;

                //Se a mensagem permite html
                message.IsBodyHtml = isHtml;

                // Mensagem
                message.Body = mensagem;

                message.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
                message.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");

                // envia o email
                smtpClient.Send(message);

                return true;
            }
            catch (Exception ex)
            {
                string msgLog = "Ocorreram problemas no envio do e-mail. E-mail remetente:" + emailRemetente + " / E-mail destinatário:" + emailDestinatario + " / Título:" + titulo + " / Erro:" + ex.Message;
                /*
                Log log = new Log() { Categoria = (int)CategoriaLog.Erro, CodEvento = 00000, IdUsuario = -1, Mensagem = msgLog };
                LogBO logBO = new LogBO();

                logBO.Salvar(log);
                */
                return false;
            }
        }

        /// <summary>
        /// Monta o modelo de email geral
        /// </summary>
        /// <param name="dadosEmail">Dados da mensagem</param>
        /// <returns></returns>
        public static string MontarModeloEmail(string dadosEmail)
        {
            string mensagem =

                "<div>" +
                    "<div style=\"margin:auto; background-color:#e7e8e9; width: 594px; text-align:center;\">" +

                        "<div style=\"background-image:url('http://www.s4w.com.br/img/logo_s4w_email.png'); background-repeat:no-repeat; height: 78px; text-align:left; margin:0px 0px 7px 10px;\"> </div>" +

                        "<div style=\"background-color:#ffffff; text-align:left; font-size:15px; font-family:Trebuchet MS, Verdana !important;\">" +
                            "<br /> <br />" +
                            "<div style=\"margin-left:15px; margin-right:20px; line-height:22px; color:#333333;\">" +
                                dadosEmail +
                            "</div>" +
                            "<br />" +
                        "</div>" +

                        "<div style=\"height: 50px; text-align:center;\">" +
                            "<div style=\"background-color:#e7e8e9; padding:18px 0px 7px 0px; margin:0px 0px 0px 0px; position:relative; font-size: 13px; color:#333333; font-family:Trebuchet MS, Verdana !important\">" +
                                "Rua dos Expedicionários, 568 | Cornélio Procópio-PR | [43] 3523 9603 | www.s4w.com.br" +
                            "</div>" +
                        "</div>" +
                    "</div>" +
                "</div>";

            return mensagem;
        }

        /// <summary>
        /// Monta o modelo de email geral com fundo cinza claro
        /// </summary>
        /// <param name="dadosEmail">Dados da mensagem</param>
        /// <returns></returns>
        public static string MontarModeloEmail_CinzaClaro(string dadosEmail)
        {
            string mensagem =

                "<div>" +
                    "<div style=\"margin:auto; background-color:#e7e8e9; width: 594px; text-align:center;\">" +

                        "<div style=\"background-image:url('http://www.s4w.com.br/img/logo_s4w_email.png'); background-repeat:no-repeat; height: 78px; text-align:left; margin:0px 0px 7px 10px;\"> </div>" +

                        "<div style=\"background-color:#ffffff; text-align:left; font-size:15px; font-family:Trebuchet MS, Verdana !important;\">" +
                            "<br /> <br />" +
                            "<div style=\"margin-left:35px !important; margin-right:20px; line-height:22px; color:#333333;\">" +
                                dadosEmail +
                            "</div>" +
                            "<br />" +
                        "</div>" +

                        "<div style=\"height: 50px; text-align:center;\">" +
                            "<div style=\"background-color:#e7e8e9; padding:18px 0px 7px 0px; margin:0px 0px 0px 0px; position:relative; font-size: 13px; color:#333333; font-family:Trebuchet MS, Verdana !important\">" +
                                "Rua dos Expedicionários, 568 | Cornélio Procópio-PR | [43] 3523 9603 | www.s4w.com.br" +
                            "</div>" +
                        "</div>" +
                    "</div>" +
                "</div>";

            return mensagem;
        }

        public void MandarEmailContato(string nome, string email, string mensagem)
        {
            var fromAddress = new MailAddress("nebulus@technoturn.com.br", "NEBULUS");
            var toAddress = new MailAddress("lucasreinaldi@gmail.com", "Lucas Reinaldi");
            const string fromPassword = "cosmiclife01";
            const string subject = "ABOUT CONTACT";
            string msg = "Nome: " + nome + "<br />Email: " + email + "<br /><br />Mensagem: " + mensagem;

            var smtp = new SmtpClient
            {
                Host = "smtp.umbler.com",
                Port = 587,
                EnableSsl = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = msg,
                IsBodyHtml = true
            })
            {
                smtp.Send(message);
            }
        }

        public void MandarEmailBooking(string nome, string email, string mensagem)
        {
            var fromAddress = new MailAddress("nebulus@technoturn.com.br", "NEBULUS");
            var toAddress = new MailAddress("lucasreinaldi@gmail.com", "Lucas Reinaldi");
            const string fromPassword = "cosmiclife01";
            const string subject = "ABOUT BOOKING";
            string msg = "Nome: " + nome + "<br />Email: " + email + "<br /><br />Mensagem: " + mensagem;

            var smtp = new SmtpClient
            {
                Host = "smtp.umbler.com",
                Port = 587,
                EnableSsl = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = msg,
                IsBodyHtml = true
            })
            {
                smtp.Send(message);
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