using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApiCore.Application.Models.Ball
{
    public class Ball
    {

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [Required]
        public string Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        /// <value>The name.</value>
        [Required]
        public string Name { get;   set; }

        public string Color { get;   set; }

    }
}