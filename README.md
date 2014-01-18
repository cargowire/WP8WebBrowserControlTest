WP8 WebBrowser Control Test
========================

A test of the web browser control on Windows Phone 8 using google maps (memory usage).

When the user navigates to the google map page and moves around the memory usage can be seen to gradually increase.

If the user returns to the main page the memory usage does drop but not to anywhere near the original usage.

Navigating back to the web browser page and moving around again will now raise the memory from this new baseline.

After doing this a few times the application will crash as it hits the 150MB limit that WP8 will tombstone you from.
