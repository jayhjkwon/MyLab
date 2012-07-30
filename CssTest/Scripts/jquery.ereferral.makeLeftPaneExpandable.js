(function ($) {

    $.extend($, {

        makeLeftPaneExpandable: function (options) {
            
            var defaults;

            defaults = {
                animationSpeed: 300
                , docListWrapperExpandWidth: 100
                , docListWrapperCollapseWidth: 30
                , thumbnailWrapperExpandWidth: 80
                , thumbnailWrapperCollapseWidth: 30
                , $docListWrapper: undefined
                , $thumbnailWrapper: undefined
                , $docViewerWrapper: undefined
                , $btnDocListExpander: undefined
                , $btnThumbnailExpander: undefined
            };
            
            // map the options object's value to the defaults object
            $.extend(defaults, options);

            // check must-have-value parameters
            if (!defaults.$docListWrapper) {
                throw new Error('The $docListWrapper in options object must have value');
                return;
            }
            if (!defaults.$thumbnailWrapper) {
                throw new Error('The $thumbnailWrapper in options object must have value');
                return;
            }
            if (!defaults.$docViewerWrapper) {
                throw new Error('The $docViewerWrapper in options object must have value');
                return;
            }
            if (!defaults.$btnDocListExpander) {
                throw new Error('The $btnDocListExpander in options object must have value');
                return;
            }
            if (!defaults.$btnThumbnailExpander) {
                throw new Error('The $btnThumbnailExpander in options object must have value');
                return;
            }
            

            defaults.$btnDocListExpander.click(function () {
                performAction(!isExpandedLeftPane(defaults), isExpandedThumbnailPane(defaults), defaults);
            });

            defaults.$btnThumbnailExpander.click(function () {
                performAction(isExpandedLeftPane(defaults), !isExpandedThumbnailPane(defaults), defaults);
            });

            return this;
        }   // end of the 'makeLeftMenuExpandable' function
    });


    // private functions
    var performAction = function (expandDoc, expandThumb, defaults) {
        var windowWidth = $(window).width();

        if (expandDoc) {
            if (expandThumb) {
                defaults.$btnDocListExpander.text('<');
                defaults.$btnThumbnailExpander.text('<');

                defaults.$docListWrapper.animate({ width: defaults.docListWrapperExpandWidth }, defaults.animationSpeed);
                defaults.$thumbnailWrapper.animate({
                    left: defaults.docListWrapperExpandWidth,
                    width: defaults.thumbnailWrapperExpandWidth
                }, defaults.animationSpeed);
                defaults.$docViewerWrapper.animate({
                    left: defaults.docListWrapperExpandWidth + defaults.thumbnailWrapperExpandWidth,
                    width: windowWidth - defaults.docListWrapperExpandWidth - defaults.thumbnailWrapperExpandWidth
                }, defaults.animationSpeed);

                defaults.$docListWrapper.children().show();
                defaults.$thumbnailWrapper.children().show();
            } else {
                defaults.$btnDocListExpander.text('<');
                defaults.$btnThumbnailExpander.text('>');

                defaults.$docListWrapper.animate({ width: defaults.docListWrapperExpandWidth }, defaults.animationSpeed);
                defaults.$thumbnailWrapper.animate({
                    left: defaults.docListWrapperExpandWidth,
                    width: defaults.thumbnailWrapperCollapseWidth
                }, defaults.animationSpeed);
                defaults.$docViewerWrapper.animate({
                    left: defaults.docListWrapperExpandWidth + defaults.thumbnailWrapperCollapseWidth,
                    width: windowWidth - defaults.docListWrapperExpandWidth - defaults.thumbnailWrapperCollapseWidth
                }, defaults.animationSpeed);

                defaults.$docListWrapper.children().show();
                defaults.$thumbnailWrapper.children().not(defaults.$btnThumbnailExpander).hide();
            }
        } else {
            if (expandThumb) {
                defaults.$btnDocListExpander.text('>');
                defaults.$btnThumbnailExpander.text('<');

                defaults.$docListWrapper.animate({ width: defaults.docListWrapperCollapseWidth }, defaults.animationSpeed);
                defaults.$thumbnailWrapper.animate({
                    left: defaults.docListWrapperCollapseWidth,
                    width: defaults.thumbnailWrapperExpandWidth
                }, defaults.animationSpeed);
                defaults.$docViewerWrapper.animate({
                    left: defaults.docListWrapperCollapseWidth + defaults.thumbnailWrapperExpandWidth,
                    width: windowWidth - defaults.docListWrapperCollapseWidth - defaults.thumbnailWrapperExpandWidth
                }, defaults.animationSpeed);

                defaults.$docListWrapper.children().not(defaults.$btnDocListExpander).hide();
                defaults.$thumbnailWrapper.children().show();
            } else {
                defaults.$btnDocListExpander.text('>');
                defaults.$btnThumbnailExpander.text('>');

                defaults.$docListWrapper.animate({ width: defaults.docListWrapperCollapseWidth }, defaults.animationSpeed);
                defaults.$thumbnailWrapper.animate({
                    left: defaults.docListWrapperCollapseWidth,
                    width: defaults.thumbnailWrapperCollapseWidth
                }, defaults.animationSpeed);
                defaults.$docViewerWrapper.animate({
                    left: defaults.docListWrapperCollapseWidth + defaults.thumbnailWrapperCollapseWidth,
                    width: windowWidth - defaults.docListWrapperCollapseWidth - defaults.thumbnailWrapperCollapseWidth
                }, defaults.animationSpeed);

                defaults.$docListWrapper.children().not(defaults.$btnDocListExpander).hide();
                defaults.$thumbnailWrapper.children().not(defaults.$btnThumbnailExpander).hide();
            }
        }
    };


    // return current status of panes, expanded or collapsed
    var isExpandedLeftPane = function (defaults) {
        if (defaults.$docListWrapper.width() ===
                defaults.docListWrapperExpandWidth) {
            return true;
        } else {
            return false;
        }
    };

    var isExpandedThumbnailPane = function (defaults) {
        if (defaults.$thumbnailWrapper.width() ===
                defaults.thumbnailWrapperExpandWidth) {
            return true;
        } else {
            return false;
        }
    };

})(jQuery);