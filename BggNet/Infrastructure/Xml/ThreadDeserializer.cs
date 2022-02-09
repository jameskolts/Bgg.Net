using Bgg.Net.Common.Infrastructure.Xml.Interfaces;
using Bgg.Net.Common.Models;
using Serilog;
using System.Xml;
using Thread = Bgg.Net.Common.Models.Thread;

namespace Bgg.Net.Common.Infrastructure.Xml
{
    public class ThreadDeserializer : DeserializerBase, IThreadDeserializer
    {
        public ThreadDeserializer(ILogger logger) : base(logger)
        {
        }

        public List<Thread> DeserializeThreads(string xml)
        {
            if (string.IsNullOrWhiteSpace(xml))
            {
                return null;
            }

            var root = GetRoot(xml);
            var threads = new List<Thread>();

            foreach (XmlNode threadNode in root.ChildNodes)
            {
                if (threadNode.Name != "thread")
                {
                    var errorMessage = $"Node '{threadNode}' cannot be deserialized into a thread.";
                    _logger.Error(errorMessage);
                    throw new XmlException(errorMessage);
                }

                var thread = DeserializeThread(threadNode);

                if (threadNode != null)
                {
                    threads.Add(thread);
                }
            }

            return threads.Any() ? threads : null;
        }

        public List<ThreadSummary> DeserializeThreadSummaries(string xml)
        {
            if (string.IsNullOrWhiteSpace(xml))
            {
                return null;
            }

            var root = GetRoot(xml);
            var summaries = new List<ThreadSummary>();

            foreach (XmlNode threadNode in root.ChildNodes)
            {
                if (threadNode.Name != "thread"){
                    var errorMessage = $"Node '{threadNode}' cannot be deserialized into a thread.";
                    _logger.Error(errorMessage);
                    throw new XmlException(errorMessage);
                }

                var threadSummary = DeserializeThreadSummary(threadNode);

                if (threadSummary != null)
                {
                    summaries.Add(threadSummary);
                }
            }

            return summaries.Any() ? summaries : null;
        }

        private ThreadSummary DeserializeThreadSummary(XmlNode threadNode)
        {
            if (threadNode == null)
            {
                return null;
            }

            var summary = new ThreadSummary
            {
                Id = DeserializeLongAttribute("id", threadNode),
                Subject = DeserializeStringAttribute("subject", threadNode),
                NumArticles = DeserializeIntAttribute("numarticles", threadNode),
                Author = DeserializeStringAttribute("author", threadNode),
                PostDate = DeserializeDtoAttribute("postdate", threadNode),
                LastPostDate = DeserializeDtoAttribute("lastpostdate", threadNode)
            };

            if (!(summary.Id.HasValue || !string.IsNullOrWhiteSpace(summary.Subject) || 
                summary.NumArticles.HasValue || !string.IsNullOrWhiteSpace(summary.Author) ||
                summary.PostDate.HasValue || summary.LastPostDate.HasValue))
            {
                return null;
            }

            return summary;
        }

        private Thread DeserializeThread(XmlNode threadNode)
        {
            if (threadNode == null)
            {
                return null;
            }

            var thread = new Thread
            {
                Id = DeserializeLongAttribute("id", threadNode),
                Subject = DeserializeStringInnerText(threadNode.SelectSingleNode("subject")),
                NumArticles = DeserializeIntAttribute("numarticles", threadNode),
                Link = DeserializeStringAttribute("link", threadNode),
                Articles = DeserializeArticles(threadNode.SelectSingleNode("articles"))
            };

            if (!(thread.Id.HasValue || !string.IsNullOrWhiteSpace(thread.Subject) ||
                thread.NumArticles.HasValue || !string.IsNullOrWhiteSpace(thread.Link) ||
                thread.Articles.Any()))
            {
                return null;
            }

            return thread;
        }

        private List<Article> DeserializeArticles(XmlNode articlesNode)
        {
            if (articlesNode == null)
            {
                return null;
            }

            List<Article> articles = new List<Article>();

            foreach (XmlNode articleNode in articlesNode)
            {
                if (articleNode.Name != "article")
                {
                    var errorMessage = $"Node '{articleNode}' cannot be deserialized into an article.";
                    _logger.Error(errorMessage);
                    throw new XmlException(errorMessage);
                }

                var article = DeserializeArticle(articleNode);

                if (article != null)
                {
                    articles.Add(article);
                }
            }

            return articles.Any() ? articles : null;
        }

        private Article DeserializeArticle(XmlNode articleNode)
        {
            if (articleNode == null)
            {
                return null;
            }

            var article = new Article
            {
                Id = DeserializeLongAttribute("id", articleNode),
                UserName = DeserializeStringAttribute("username", articleNode),
                Link = DeserializeStringAttribute("link", articleNode),
                PostDate = DeserializeDtoAttribute("postdate", articleNode),
                EditDate = DeserializeDtoAttribute("editdate", articleNode),
                NumEdits = DeserializeIntAttribute("numedits", articleNode),
                Subject = DeserializeStringInnerText(articleNode.SelectSingleNode("subject")),
                Body = DeserializeStringInnerText(articleNode.SelectSingleNode("body"))
            };

            if (!(article.Id.HasValue || !string.IsNullOrWhiteSpace(article.UserName) ||
                !string.IsNullOrWhiteSpace(article.Link) || article.PostDate.HasValue ||
                article.EditDate.HasValue || article.NumEdits.HasValue || 
                !string.IsNullOrWhiteSpace(article.Subject) || !string.IsNullOrWhiteSpace(article.Body)))
            {
                return null;
            }

            return article;
        }
    }
}
