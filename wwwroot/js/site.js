document.addEventListener('DOMContentLoaded', function () {
  const menuToggle = document.querySelector('.menu-toggle');
  const navMenu = document.querySelector('.nav-menu');

  // Mobile menu toggle
  if (menuToggle && navMenu) {
    menuToggle.addEventListener('click', function () {
      menuToggle.classList.toggle('active');
      navMenu.classList.toggle('active');
    });
  }

  // Initially show the first set of projects and activate the first button
  const firstButton = document.querySelector('.project-buttons button');
  if (firstButton) {
    showProjects(1, firstButton);
  }
});

// Eye movement logic
const eyes = document.querySelectorAll('.eye');
const pupils = document.querySelectorAll('.pupil');

document.addEventListener('mousemove', (event) => {
  eyes.forEach((eye, index) => {
    const eyeRect = eye.getBoundingClientRect();
    const eyeCenterX = eyeRect.left + eyeRect.width / 2;
    const eyeCenterY = eyeRect.top + eyeRect.height / 2;

    const angle = Math.atan2(event.clientY - eyeCenterY, event.clientX - eyeCenterX);
    const maxDistance = 30;
    const pupilX = Math.cos(angle) * maxDistance;
    const pupilY = Math.sin(angle) * maxDistance;

    pupils[index].style.transform = `translate(${pupilX}px, ${pupilY}px)`;
  });
});


// Projects

function filterProjects(category, button) {
  // Get all buttons and remove the 'active' class from them
  const buttons = document.querySelectorAll('.project-buttons button');
  buttons.forEach(btn => btn.classList.remove('active'));

  // Add 'active' class to the clicked button
  button.classList.add('active');

  // Logic to filter projects based on the category (already implemented)
  const projectItems = document.querySelectorAll('.project-item');

  projectItems.forEach(item => {
    const itemCategory = item.getAttribute('data-category');
    if (category === 'all' || itemCategory === category) {
      item.classList.remove('hidden');
    } else {
      item.classList.add('hidden');
    }
  });
}




function openProject(projectId) {
  const slideWindow = document.getElementById('project-slide-window');
  const projectDetails = document.getElementById('project-details');
  const blurOverlay = document.getElementById('blur-overlay');

  // Add unique content dynamically based on projectId
  let content = '';
  switch (projectId) {
    case 1:
      content = `
                <div style="padding: 20px; color: #333;">
                    <h2 style="color: white;font-weight: 800;margin-top: 1.5rem;">My Personal Website</h2>
                    <img src="/img/project1.jpg" alt="Project 1" style="width:100%; max-width: 500px; height: auto; border-radius: 8px; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2); object-fit:cover;">
                    
                    <h3 style = "color : white; font-size: 1.124em ;margin-top: 2rem;margin-bottom: 0.8rem;">About</h3>
                   
                    <p style="color: white; margin: 10px 0;">My personal website that showcase all of my project using .net framework.</p>
                   
                    <h4 style = "color : white; font-size = 1em;margin-top: 2rem;margin-bottom: 0.8rem;"> Technologies<h4>
                    <p2 style = "display:flex">
                    <span style = "background : red; color : white; padding : 6px 13px; border-radius:4px;text-transform:capitalize;font-size:11px;margin-right:6px;font-weight:700;">ASP.Net</span>
                    <span style = "background : red; color : white; padding : 6px 13px; border-radius:4px;text-transform:capitalize;font-size:11px;margin-right:6px;font-weight:700;">CSS</span>
                    <span style = "background : red; color : white; padding : 6px 13px; border-radius:4px;text-transform:capitalize;font-size:11px;margin-right:6px;font-weight:700;">JS</span>
                    <span style = "background : red; color : white; padding : 6px 13px; border-radius:4px;text-transform:capitalize;font-size:11px;margin-right:6px;font-weight:700;">Razor Page</span>
                    </p2>
                    
                    <h5 style = "color : white; font-size: 1.124em ;margin-top: 2rem;margin-bottom: 0.8rem;">Website</h5>
                    <p>
                    <a href="https://www.example.com/project1" target="_blank" style="color: #007BFF; text-decoration: none; font-weight: bold;">Learn More</a>
                    </p>
                </div>
          `;
      break;
    case 2:
      content = `
             <div style="padding: 20px; color: #333;">
                    <h2 style="color: white;font-weight: 800;margin-top: 1.5rem;">My Personal Website</h2>
                    <img src="/img/P2-1.png" alt="Project 2" style="width:100%; max-width: 500px; height: auto; border-radius: 8px; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2); object-fit:cover;">
                    
                    <h3 style = "color : white; font-size: 1.124em ;margin-top: 2rem;margin-bottom: 0.8rem;">About</h3>
                   
                    <p style="color: white; margin: 10px 0;">My personal website that showcase all of my project using .net framework.</p>
                   
                    <h4 style = "color : white; font-size = 1em;margin-top: 2rem;margin-bottom: 0.8rem;"> Technologies<h4>
                    <p2 style = "display:flex">
                    <span style = "background : red; color : white; padding : 6px 13px; border-radius:4px;text-transform:capitalize;font-size:11px;margin-right:6px;font-weight:700;">.Net</span>
                    <span style = "background : red; color : white; padding : 6px 13px; border-radius:4px;text-transform:capitalize;font-size:11px;margin-right:6px;font-weight:700;">CSS</span>
                    <span style = "background : red; color : white; padding : 6px 13px; border-radius:4px;text-transform:capitalize;font-size:11px;margin-right:6px;font-weight:700;">JS</span>

                    </p2>
                    
                    <h5 style = "color : white; font-size: 1.124em ;margin-top: 2rem;margin-bottom: 0.8rem;">Website</h5>
                    <p>
                    <a href="https://www.example.com/project1" target="_blank" style="color: #007BFF; text-decoration: none; font-weight: bold;">Learn More</a>
                    </p>
                </div>
          `;
      break;
    case 3:
      content = `
              <div style="padding: 20px; color: #333;">
                    <h2 style="color: white;font-weight: 800;margin-top: 1.5rem;">My Personal Website</h2>
                    <img src="/img/P3-1.png" alt="Project 3" style="width:100%; max-width: 500px; height: auto; border-radius: 8px; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2); object-fit:cover;">
                    
                    <h3 style = "color : white; font-size: 1.124em ;margin-top: 2rem;margin-bottom: 0.8rem;">About</h3>
                   
                    <p style="color: white; margin: 10px 0;">My personal website that showcase all of my project using .net framework.</p>
                   
                    <h4 style = "color : white; font-size = 1em;margin-top: 2rem;margin-bottom: 0.8rem;"> Technologies<h4>
                    <p2 style = "display:flex">
                    <span style = "background : red; color : white; padding : 6px 13px; border-radius:4px;text-transform:capitalize;font-size:11px;margin-right:6px;font-weight:700;">.Net</span>
                    <span style = "background : red; color : white; padding : 6px 13px; border-radius:4px;text-transform:capitalize;font-size:11px;margin-right:6px;font-weight:700;">CSS</span>
                    <span style = "background : red; color : white; padding : 6px 13px; border-radius:4px;text-transform:capitalize;font-size:11px;margin-right:6px;font-weight:700;">JS</span>
                     
                    </p2>
                    
                    <h5 style = "color : white; font-size: 1.124em ;margin-top: 2rem;margin-bottom: 0.8rem;">Website</h5>
                    <p>
                    <a href="https://www.example.com/project1" target="_blank" style="color: #007BFF; text-decoration: none; font-weight: bold;">Learn More</a>
                    </p>
                </div>
          `;
      break;
    // Add more cases for other projects as needed
    default:
      content = `<h2>Project not found</h2>`;
      break;
  }

  // Inject the content into the slide window
  projectDetails.innerHTML = content;

  // Show the sliding window and blur overlay
  slideWindow.classList.add('active');
  blurOverlay.classList.add('active');

  // Add event listener for clicking outside the slide window (on the blur overlay)
  blurOverlay.addEventListener('click', closeProject);
}

function closeProject() {
  const slideWindow = document.getElementById('project-slide-window');
  const blurOverlay = document.getElementById('blur-overlay');

  // Hide the sliding window and blur overlay
  slideWindow.classList.remove('active');
  blurOverlay.classList.remove('active');

  // Remove the event listener for clicking outside the slide window
  blurOverlay.removeEventListener('click', closeProject);
}

// JavaScript to handle theme toggle
const toggleButton = document.getElementById('theme-toggle');
const currentTheme = localStorage.getItem('theme') || 'dark'; // Default to dark if no preference

// Set the current theme on page load
document.documentElement.setAttribute('data-theme', currentTheme);


toggleButton.addEventListener('click', () => {
  const theme = document.documentElement.getAttribute('data-theme');

  if (theme === 'dark') {
    document.documentElement.setAttribute('data-theme', 'light');
    localStorage.setItem('theme', 'light');
    
  } else {
    document.documentElement.setAttribute('data-theme', 'dark');
    localStorage.setItem('theme', 'dark');
    
  }
});

//Contact

document.addEventListener("DOMContentLoaded", function () {
  var contactForm = document.getElementById("contactForm");
  contactForm.onsubmit = function (event) {
      event.preventDefault(); // Prevent the default form submission

      // Get the message from the hidden input
      var message = document.getElementById("alert-message").value;
      if (message) {
          alert(message); // Show alert if message exists
      }

      // Optionally, submit the form programmatically
      // contactForm.submit(); // Uncomment this line if you want to submit after alert
  };
});

