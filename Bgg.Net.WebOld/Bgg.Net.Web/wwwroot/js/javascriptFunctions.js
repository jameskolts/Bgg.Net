window.methods = {

    formatQuotes: function () {
        let quoteBlock = document.getElementsByClassName('quote');
        if (quoteBlock) {

            for (var i = 0; i < quoteBlock.length; i++) {
                quoteBlock[i].classList.add("thread-quotes");
            }
        }
    }
}