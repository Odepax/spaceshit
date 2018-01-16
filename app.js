let observer = new IntersectionObserver(observables => {
	for (const observable of observables) {
		if (observable.intersectionRatio > 0.5) {
			for (const element of document.getElementsByClassName(observable.target.dataset.highlight)) {
				element.classList.add("highlight")
			}
		} else {
			for (const element of document.getElementsByClassName(observable.target.dataset.highlight)) {
				element.classList.remove("highlight")
			}
		}
	}
}, { threshold: [ 0.5 ] })

for (const element of document.querySelectorAll("#syntax-elements .scrolling-block div[data-highlight]")) {
	observer.observe(element)
}
